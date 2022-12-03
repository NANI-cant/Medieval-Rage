using System.Collections.Generic;
using Architecture.Services.Factories;
using Architecture.Services.General;
using Gameplay.Setup;
using UnityEngine;

namespace Architecture.Services.Gameplay.Impl {
    public class SpawnEnemiesService : ISpawnEnemiesService {
        private readonly IEnemySpawner[] _enemySpawners;
        private readonly IGameplayFactory _factory;
        private readonly IRandomService _randomService;

        public SpawnEnemiesService(
            IEnemySpawner[] enemySpawners,
            IGameplayFactory factory,
            IRandomService randomService
        ) {
            _enemySpawners = enemySpawners;
            _factory = factory;
            _randomService = randomService;
        }
        
        public void Spawn() {
            foreach (var spawner in _enemySpawners) {
                if(!spawner.IsSlayed) continue;
                
                EnemyPack[] allPacks = spawner.Packs;
                var randomIndex = _randomService.Range(0, allPacks.Length);
                var pack = allPacks[randomIndex];

                List<GameObject> enemies = new();
                foreach (var enemyId in pack.Enemies) {
                    var enemy = _factory.CreateEnemy(enemyId, spawner.Position, spawner.Rotation);
                    enemies.Add(enemy);
                }
                spawner.Track(enemies.ToArray());
            }
        }
    }
}