using Architecture.Services.General;
using Architecture.Services.Teaming;
using ExitGames.Client.Photon;
using Gameplay.Teaming;
using Network.Utils;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Architecture.Services.Network.Impl {
    public class GameplayNetworkFactory: IOnEventCallback {
        private readonly INetworkPrefabProvider _prefabProvider;
        private readonly IInstantiateProvider _instantiateProvider;
        private readonly ITeamProvider _teamProvider;
        private readonly INetworkService _networkService;

        public GameplayNetworkFactory(
            INetworkPrefabProvider prefabProvider,
            IInstantiateProvider instantiateProvider,
            ITeamProvider teamProvider,
            INetworkService networkService
        ) {
            _prefabProvider = prefabProvider;
            _instantiateProvider = instantiateProvider;
            _teamProvider = teamProvider;
            _networkService = networkService;
            
            _networkService.AddCallbackTarget(this);
        }
        
        public void OnEvent(EventData photonEvent) {
            if (photonEvent.Code == NetworkInstantiationCode.Player) {
                object[] data = (object[]) photonEvent.CustomData;
                CreatePlayer((int) data[2], (Vector3) data[0], (Quaternion) data[1]);
            }
        }

        private void CreatePlayer(int id, Vector3 position, Quaternion rotation) {
            GameObject player = _instantiateProvider.Instantiate(_prefabProvider.Player, position, rotation);
            player.GetComponent<PhotonView>().ViewID = id;
            player.GetComponent<Team>().Construct(_teamProvider.NextPlayerTeamId);
        }
    }
}