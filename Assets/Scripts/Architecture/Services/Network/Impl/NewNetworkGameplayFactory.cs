using System;
using Architecture.Services.AssetProviding;
using Architecture.Services.Factories;
using Architecture.Services.Factories.Impl;
using Architecture.Services.Gameplay;
using Architecture.Services.General;
using Architecture.Services.Teaming;
using ExitGames.Client.Photon;
using Gameplay.Enemy;
using Gameplay.Fighting;
using Gameplay.Health;
using Gameplay.Player;
using Gameplay.Setup;
using Gameplay.Teaming;
using Network.Utils;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Architecture.Services.Network.Impl {
    public class NewNetworkGameplayFactory: IOnEventCallback {
        private readonly INetworkPrefabProvider _networkPrefabProvider;
        private readonly IMetricProvider _metricProvider;
        private readonly IInstantiateProvider _instantiateProvider;
        private readonly IPrefabProvider _prefabProvider;
        private readonly ITeamProvider _teamProvider;
        private readonly IAgentPriorityProvider _agentPriorityProvider;
        private readonly IInputService _inputService;
        private readonly ITimeProvider _timeProvider;
        private readonly IRandomService _randomService;

        public NewNetworkGameplayFactory(
            INetworkService networkService,
            INetworkPrefabProvider networkPrefabProvider,
            IMetricProvider metricProvider,
            IInstantiateProvider instantiateProvider,
            IPrefabProvider prefabProvider,
            ITeamProvider teamProvider,
            IAgentPriorityProvider agentPriorityProvider,
            IInputService inputService,
            ITimeProvider timeProvider,
            IRandomService randomService
        ) {
            _networkPrefabProvider = networkPrefabProvider;
            _metricProvider = metricProvider;
            _instantiateProvider = instantiateProvider;
            _prefabProvider = prefabProvider;
            _teamProvider = teamProvider;
            _agentPriorityProvider = agentPriorityProvider;
            _inputService = inputService;
            _timeProvider = timeProvider;
            _randomService = randomService;

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
            GameObject player = _instantiateProvider.Instantiate(_networkPrefabProvider.Player, position, rotation);
            var playerMetric = _metricProvider.PlayerMetric;
            
            player.GetComponent<Health>().Construct(playerMetric.MaxHealth);
            player.GetComponent<Team>().Construct(_teamProvider.NextPlayerTeamId);
            player.GetComponent<PhotonView>().ViewID = viewId;
        }

        private void CreateEnemy(int viewId, EnemyId enemyId, Vector3 position, Quaternion rotation) {
            var enemy = _instantiateProvider.Instantiate(_prefabProvider.Enemy(enemyId), position, rotation);
            var enemyMetric = _metricProvider.EnemyMetric(enemyId);
            
            enemy.GetComponent<Aggro>().Construct(enemyMetric.AggroDuration, enemyMetric.AggroRadius, _timeProvider);
            enemy.GetComponent<AIMover>().Construct(enemyMetric.Speed, enemyMetric.AngularSpeed, _agentPriorityProvider.NextPriority);
            enemy.GetComponent<AutoAttack>().Construct(enemyMetric.AttackCooldown, enemyMetric.AttackRadius, enemyMetric.AttackData, _timeProvider);
            enemy.GetComponent<Health>().Construct(enemyMetric.MaxHealth);
            enemy.GetComponent<AttackTargetPriority>().Construct(enemyMetric.AttackTargetPriority);
            enemy.GetComponent<EnemyAnimator>().Construct(enemyMetric.AttackSpeed, _randomService);
            enemy.GetComponent<Rotator>().Construct(enemyMetric.AngularSpeed, _timeProvider);
            enemy.GetComponent<Team>().Construct(_teamProvider.EnemyTeamId);
            
            enemy.GetComponent<PhotonView>().ViewID = viewId;
            enemy.GetComponent<Enemy>().Construct(false);
        }
    }
}