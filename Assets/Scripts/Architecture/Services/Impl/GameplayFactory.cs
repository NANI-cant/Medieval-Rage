using System.Collections.Generic;
using Gameplay.Enemy;
using Gameplay.Health;
using Gameplay.Player;
using Gameplay.Setup;
using UnityEngine;

namespace Architecture.Services.Impl {
    public class GameplayFactory : IGameplayFactory {
        private const string ContainerSuffix = "Container";
        private const string PlayerKey = "Player";

        private readonly IPrefabProvider _prefabProvider;
        private readonly IMetricProvider _metricProvider;
        private readonly IInputService _inputService;
        private readonly IInstantiateProvider _instantiateProvider;
        private readonly ITimeProvider _timeProvider;
        private readonly Dictionary<string, Transform> _containers = new();

        public GameplayFactory(
            IPrefabProvider prefabProvider,
            IMetricProvider metricProvider,
            IInputService inputService,
            IInstantiateProvider instantiateProvider,
            ITimeProvider timeProvider
        ) {
            _prefabProvider = prefabProvider;
            _metricProvider = metricProvider;
            _inputService = inputService;
            _instantiateProvider = instantiateProvider;
            _timeProvider = timeProvider;
        }

        public GameObject CreatePlayerCharacter(Vector3 position, Quaternion rotation) {
            var container = GetContainerFor(PlayerKey);
            var player = _instantiateProvider.Instantiate(_prefabProvider.PlayerCharacter, position, rotation, container);

            player.GetComponent<PlayerInputBrain>().Construct(_inputService);
            player.GetComponent<Mover>().Construct(_metricProvider.PlayerMetric.Speed);

            return player;
        }

        public GameObject CreateEnemy(EnemyId enemyId, Vector3 position, Quaternion rotation) {
            var container = GetContainerFor(enemyId.ToString());
            var enemy = _instantiateProvider.Instantiate(_prefabProvider.Enemy(enemyId), position, rotation, container);
            var enemyMetric = _metricProvider.EnemyMetric;
            
            enemy.GetComponent<Aggro>().Construct(enemyMetric.AggroDuration);
            enemy.GetComponent<AIMover>().Construct(enemyMetric.Speed);
            enemy.GetComponent<AutoAttacker>().Construct(enemyMetric.AttackCooldown, enemyMetric.AttackData, _timeProvider);
            enemy.GetComponent<Health>().Construct(enemyMetric.MaxHealth);
            
            return enemy;
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
