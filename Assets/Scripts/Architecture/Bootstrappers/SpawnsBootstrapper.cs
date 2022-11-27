using Gameplay.Setup;
using Gameplay.Setup.Impl;
using UnityEngine;
using Zenject;

namespace Architecture.Bootstrappers {
    public class SpawnsBootstrapper : MonoInstaller {
        public override void InstallBindings() {
            foreach (var playerSpawner in CollectPlayerSpawners()) {
                Container.Bind<IPlayerSpawner>().FromInstance(playerSpawner).NonLazy();
            }
            
            foreach (var enemySpawner in CollectEnemySpawnPoints()) {
                Container.Bind<IEnemySpawner>().FromInstance(enemySpawner).NonLazy();
            }

            foreach (var traderSpawner in CollectTraderSpawnPoints()) {
                Container.Bind<ITraderSpawner>().FromInstance(traderSpawner).NonLazy();
            }
        }

        private IPlayerSpawner[] CollectPlayerSpawners() => FindObjectsOfType<PlayerSpawner>();
        private IEnemySpawner[] CollectEnemySpawnPoints() => FindObjectsOfType<EnemySpawner>();
        private ITraderSpawner[] CollectTraderSpawnPoints() => FindObjectsOfType<TraderSpawner>();
    }    
}
