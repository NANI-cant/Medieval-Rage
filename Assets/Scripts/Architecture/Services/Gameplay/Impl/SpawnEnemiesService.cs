using System.Collections.Generic;
using Architecture.Services.Factories;
using Architecture.Services.General;
using Gameplay.Setup;
using UnityEngine;

namespace Architecture.Services.Gameplay.Impl {
    public class SpawnEnemiesService : ISpawnEnemiesService {
        private readonly IEnemySpawner[] _enemySpawners;
        private readonly IBossSpawner _bossSpawner;
        private readonly IGameplayFactory _factory;
        private readonly IRandomService _randomService;

        public SpawnEnemiesService(
            IEnemySpawner[] enemySpawners,
            IBossSpawner bossSpawner,
            IGameplayFactory factory,
            IRandomService randomService
        ) {
            _enemySpawners = enemySpawners;
            _bossSpawner = bossSpawner;
            _factory = factory;
            _randomService = randomService;
        }

        public void SpawnBoss() {
            if(!_bossSpawner.IsSlayed) return;

            var boss = _factory.CreateEnemy(_bossSpawner.BossId, _bossSpawner.Position, _bossSpawner.Rotation);
            _bossSpawner.Track(boss);
        }
        
        public void Spawn() {
            foreach (var spawner in _enemySpawners) {
                if(!spawner.IsSlayed) continue;
                
                EnemyPack pack = PickRandomPack(spawner);
                List<GameObject> enemies = CreateEnemies(pack, spawner);
                spawner.Track(enemies.ToArray());
            }
        }

        private EnemyPack PickRandomPack(IEnemySpawner spawner) {
            EnemyPack[] allPacks = spawner.Packs;
            var randomIndex = _randomService.Range(0, allPacks.Length);
            var pack = allPacks[randomIndex];
            return pack;
        }

        private List<GameObject> CreateEnemies(EnemyPack pack, IEnemySpawner spawner) {
            List<GameObject> createdEnemies = new();

            Vector3[] subPoints = TakePointsOverPerimeter(pack.Enemies.Length, spawner.SpawningRadius);
            for (int i = 0; i < pack.Enemies.Length; i++) {
                var enemyId = pack.Enemies[i];
                var position = spawner.Position + subPoints[i];
                var enemy = _factory.CreateEnemy(enemyId, position, spawner.Rotation);
                createdEnemies.Add(enemy);
            }

            return createdEnemies;
        }

        private Vector3[] TakePointsOverPerimeter(int count, float radius) {
            if (count == 1) return new Vector3[]{Vector3.zero, };
            
            Vector3[] points = new Vector3[count];

            float deltaAngle = 360f / count;
            Vector3 pointer = Vector3.forward * radius;
            for (int i = 0; i < count; i++) {
                points[i] = Quaternion.Euler(0, deltaAngle * i, 0) * pointer;
            }
            
            return points;
        }
    }
}