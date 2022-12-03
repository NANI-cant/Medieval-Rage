using Architecture.Services.General;
using Architecture.Services.Teaming;
using ExitGames.Client.Photon;
using Gameplay.Setup;
using Gameplay.Teaming;
using Network.Utils;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Architecture.Services.Network.Impl {
    public class NetworkGameplayFactory: IOnEventCallback {
        private readonly INetworkPrefabProvider _prefabProvider;
        private readonly IInstantiateProvider _instantiateProvider;
        private readonly ITeamProvider _teamProvider;

        public NetworkGameplayFactory(
            INetworkPrefabProvider prefabProvider,
            IInstantiateProvider instantiateProvider,
            ITeamProvider teamProvider,
            INetworkService networkService
        ) {
            _prefabProvider = prefabProvider;
            _instantiateProvider = instantiateProvider;
            _teamProvider = teamProvider;

            networkService.AddCallbackTarget(this);
        }
        
        public void OnEvent(EventData photonEvent) {
            object[] data = (object[]) photonEvent.CustomData;
            switch (photonEvent.Code) {
                case NetworkCode.InstantiatePlayer: {
                    CreatePlayer((int) data[2], (Vector3) data[0], (Quaternion) data[1]);
                    break;
                }
                case NetworkCode.InstantiateEnemy: {
                    CreateEnemy((int) data[0], (EnemyId) data[1], (Vector3) data[2], (Quaternion) data[3]);
                    break;
                }
            }
        }

        private void CreatePlayer(int viewId, Vector3 position, Quaternion rotation) {
            GameObject player = _instantiateProvider.Instantiate(_prefabProvider.Player, position, rotation);
            player.GetComponent<PhotonView>().ViewID = viewId;
            player.GetComponent<Team>().Construct(_teamProvider.NextPlayerTeamId);
        }

        private void CreateEnemy(int viewId, EnemyId enemyId, Vector3 position, Quaternion rotation) {
            GameObject enemy = _instantiateProvider.Instantiate(_prefabProvider.Enemy(enemyId), position, rotation);
            enemy.GetComponent<PhotonView>().ViewID = viewId;
            enemy.GetComponent<Team>().Construct(_teamProvider.EnemyTeamId);
        }
    }
}