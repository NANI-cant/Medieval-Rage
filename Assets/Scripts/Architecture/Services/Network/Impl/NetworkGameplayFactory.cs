using Architecture.Services.General;
using Architecture.Services.Teaming;
using ExitGames.Client.Photon;
using Gameplay.Health;
using Gameplay.Setup;
using Gameplay.Teaming;
using Network.Utils;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Architecture.Services.Network.Impl {
    public class NetworkGameplayFactory: IOnEventCallback {
        private readonly INetworkPrefabProvider _prefabProvider;
        private readonly IMetricProvider _metricProvider;
        private readonly IInstantiateProvider _instantiateProvider;
        private readonly ITeamProvider _teamProvider;

        public NetworkGameplayFactory(
            INetworkPrefabProvider prefabProvider,
            IMetricProvider metricProvider,
            IInstantiateProvider instantiateProvider,
            ITeamProvider teamProvider,
            INetworkService networkService
        ) {
            _prefabProvider = prefabProvider;
            _metricProvider = metricProvider;
            _instantiateProvider = instantiateProvider;
            _teamProvider = teamProvider;

            networkService.AddCallbackTarget(this);
        }
        
        public void OnEvent(EventData photonEvent) {
            switch (photonEvent.Code) {
                case NetworkCode.InstantiatePlayer: {
                    object[] data = (object[]) photonEvent.CustomData;
                    CreatePlayer((int) data[2], (Vector3) data[0], (Quaternion) data[1]);
                    break;
                }
                case NetworkCode.InstantiateEnemy: {
                    object[] data = (object[]) photonEvent.CustomData;
                    CreateEnemy((int) data[0], (EnemyId) data[1], (Vector3) data[2], (Quaternion) data[3]);
                    break;
                }
            }
        }

        private void CreatePlayer(int viewId, Vector3 position, Quaternion rotation) {
            GameObject player = _instantiateProvider.Instantiate(_prefabProvider.Player, position, rotation);
            var playerMetric = _metricProvider.PlayerMetric;
            
            player.GetComponent<Health>().Construct(playerMetric.MaxHealth);
            player.GetComponent<PhotonView>().ViewID = viewId;
            player.GetComponent<Team>().Construct(_teamProvider.NextPlayerTeamId);
        }

        private void CreateEnemy(int viewId, EnemyId enemyId, Vector3 position, Quaternion rotation) {
            GameObject enemy = _instantiateProvider.Instantiate(_prefabProvider.Enemy(enemyId), position, rotation);
            var enemyMetric = _metricProvider.EnemyMetric(enemyId);
            
            enemy.GetComponent<Health>().Construct(enemyMetric.MaxHealth);
            enemy.GetComponent<PhotonView>().ViewID = viewId;
            enemy.GetComponent<Team>().Construct(_teamProvider.EnemyTeamId);
        }
    }
}