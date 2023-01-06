using Architecture.Services.Gameplay.Impl;
using Architecture.Services.Network.Impl;
using Zenject;

namespace Architecture.Bootstrappers {
    public class GameplayNetworkBootstrapper : MonoInstaller {
        public override void InstallBindings() {
            BindService<ResourcesNetworkPrefabProvider>();
            
            BindService<GameNetEventsService>();
            BindService<SpawnEnemiesAvatarsService>();
            
            BindService<NetworkGameplayFactory>();
            BindService<GameplayFactorySync>();
        }

        private void BindService<TService>() 
            => Container.BindInterfacesAndSelfTo<TService>().AsSingle().NonLazy();
    }
}