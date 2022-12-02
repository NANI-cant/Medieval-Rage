using System.Collections.Generic;
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

namespace Architecture.Services.Impl {
    public class GameplayFactory : IGameplayFactory {
        private const string ContainerSuffix = "Container";
        private const string PlayerKey = "Player";

        private readonly IPrefabProvider _prefabProvider;
        private readonly IMetricProvider _metricProvider;
        private readonly ITeamProvider _teamProvider;
        private readonly IInputService _inputService;
        private readonly IInstantiateProvider _instantiateProvider;
        private readonly IDestroyProvider _destroyProvider;
        private readonly ITimeProvider _timeProvider;
        private readonly IRandomService _randomService;
        private readonly Dictionary<string, Transform> _containers = new();

        public GameplayFactory(
            IPrefabProvider prefabProvider,
            IMetricProvider metricProvider,
            ITeamProvider teamProvider,
            IInputService inputService,
            IInstantiateProvider instantiateProvider,
            IDestroyProvider destroyProvider,
            ITimeProvider timeProvider,
            IRandomService randomService
        ) {
            _prefabProvider = prefabProvider;
            _metricProvider = metricProvider;
            _teamProvider = teamProvider;
            _inputService = inputService;
            _instantiateProvider = instantiateProvider;
            _destroyProvider = destroyProvider;
            _timeProvider = timeProvider;
            _randomService = randomService;
        }

        public GameObject CreatePlayerCharacter(Vector3 position, Quaternion rotation) {
            var container = GetContainerFor(PlayerKey);
            var player = _instantiateProvider.Instantiate(_prefabProvider.Player, position, rotation, container);
            
            SendPlayerThroughNetwork(player);
            var playerMetric = _metricProvider.PlayerMetric;
            
            player.GetComponent<PlayerInputBrain>().Construct(_inputService);
            player.GetComponent<Mover>().Construct(playerMetric.Speed);
            player.GetComponent<Rotator>().Construct(playerMetric.AngularSpeed, _timeProvider);
            player.GetComponent<AutoAttack>().Construct(playerMetric.CoolDown, playerMetric.AttackRadius, playerMetric.AttackData, _timeProvider);
            player.GetComponent<CharacterAnimator>().Construct(playerMetric.AttackSpeed, _randomService);
            player.GetComponent<AttackTargetPriority>().Construct(playerMetric.AttackTargetPriority);
            player.GetComponent<Health>().Construct(playerMetric.MaxHealth);
            player.GetComponent<Team>().Construct(_teamProvider.NextPlayerTeamId);

            return player;
        }

        public GameObject CreateEnemy(EnemyId enemyId, Vector3 position, Quaternion rotation) {
            var container = GetContainerFor(enemyId.ToString());
            var enemy = _instantiateProvider.Instantiate(_prefabProvider.Enemy(enemyId), position, rotation, container);
            var enemyMetric = _metricProvider.EnemyMetric(enemyId);
            
            enemy.GetComponent<Aggro>().Construct(enemyMetric.AggroDuration, enemyMetric.AggroRadius, _timeProvider);
            enemy.GetComponent<AIMover>().Construct(enemyMetric.Speed);
            enemy.GetComponent<AutoAttack>().Construct(enemyMetric.AttackCooldown, enemyMetric.AttackRadius, enemyMetric.AttackData, _timeProvider);
            enemy.GetComponent<Health>().Construct(enemyMetric.MaxHealth);
            enemy.GetComponent<AttackTargetPriority>().Construct(enemyMetric.AttackTargetPriority);
            enemy.GetComponent<EnemyAnimator>().Construct(enemyMetric.AttackSpeed, _randomService);
            enemy.GetComponent<Rotator>().Construct(enemyMetric.AngularSpeed, _timeProvider);
            enemy.GetComponent<Team>().Construct(_teamProvider.EnemyTeamId);
            
            return enemy;
        }

        private void SendPlayerThroughNetwork(GameObject player) {
            var photonView = player.GetComponent<PhotonView>();
            if (PhotonNetwork.AllocateViewID(photonView)) {
                object[] data = new object[] {
                    player.transform.position,
                    player.transform.rotation,
                    photonView.ViewID
                };

                RaiseEventOptions raiseEventOptions = new RaiseEventOptions() {
                    Receivers = ReceiverGroup.Others,
                    CachingOption = EventCaching.AddToRoomCache
                };

                SendOptions sendOptions = new SendOptions() {
                    Reliability = true
                };

                PhotonNetwork.RaiseEvent(NetworkInstantiationCode.Player, data, raiseEventOptions, sendOptions);
            }
            else {
                Debug.LogError("Failed to allocate a ViewId.");
                _destroyProvider.Destroy(player);
            }
        }

        private Transform GetContainerFor(string key) {
            string containerKey = key + ContainerSuffix;
            if (!_containers.ContainsKey(containerKey)) {
                _containers[containerKey] = new GameObject(containerKey).transform;
            }

            Transform container = _containers[containerKey];
            return container;
        }
    }
}
