using Architecture.Services.Network.Impl;
using Zenject;

namespace Architecture.Bootstrappers {
    public class GameplayNetworkBootstrapper : MonoInstaller {
        public override void InstallBindings() {
            BindService<NetworkGameplayFactory>();
            BindService<GameplayFactorySync>();
            BindService<ResourcesNetworkPrefabProvider>();
            BindService<GameClockSync>();
        }

        private void BindService<TService>() 
            => Container.BindInterfacesAndSelfTo<TService>().AsSingle().NonLazy();
    }
}