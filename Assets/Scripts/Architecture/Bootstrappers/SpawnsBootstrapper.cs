using Gameplay.Setup;
using Gameplay.Setup.Impl;
using Zenject;

namespace Architecture.Bootstrappers {
    public class SpawnsBootstrapper : MonoInstaller {
        public override void InstallBindings() {
            foreach (var playerSpawner in CollectPlayerSpawners()) {
                Container.Bind<IPlayerSpawner>().FromInstance(playerSpawner).NonLazy();
            }
            
            foreach (var enemySpawner in CollectEnemySpawners()) {
                Container.Bind<IEnemySpawner>().FromInstance(enemySpawner).NonLazy();
            }

            foreach (var traderSpawner in CollectTraderSpawners()) {
                Container.Bind<ITraderSpawner>().FromInstance(traderSpawner).NonLazy();
            }

            Container.Bind<IBossSpawner>().FromInstance(CollectBossSpawner()).NonLazy();
        }

        private IPlayerSpawner[] CollectPlayerSpawners() => FindObjectsOfType<PlayerSpawner>();
        private ITraderSpawner[] CollectTraderSpawners() => FindObjectsOfType<TraderSpawner>();
        private IEnemySpawner[] CollectEnemySpawners() => FindObjectsOfType<EnemySpawner>();
        private IBossSpawner CollectBossSpawner() => FindObjectOfType<BossSpawner>();
    }    
}
