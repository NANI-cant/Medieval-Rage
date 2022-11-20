using Gameplay.Setup;
using Gameplay.Setup.Impl;
using UnityEngine;
using Zenject;

namespace Architecture.Bootstrappers {
    public class SpawnsBootstrapper : MonoInstaller {
        [SerializeField] private PlayerSpawnPoint _playerSpawnPoint;

        public override void InstallBindings() {
            Container.Bind<IPlayerSpawnPoint>().FromInstance(_playerSpawnPoint).AsSingle().NonLazy();
            
            foreach (var enemySpawnPoint in CollectEnemySpawnPoints()) {
                Container.Bind<IEnemySpawnPoint>().FromInstance(enemySpawnPoint).NonLazy();
            }

            foreach (var traderSpawnPoint in CollectTraderSpawnPoints()) {
                Container.Bind<ITraderSpawnPoint>().FromInstance(traderSpawnPoint).NonLazy();
            }
        }

        private IEnemySpawnPoint[] CollectEnemySpawnPoints() => FindObjectsOfType<EnemySpawnPoint>();
        private ITraderSpawnPoint[] CollectTraderSpawnPoints() => FindObjectsOfType<TraderSpawnPoint>();
    }    
}
