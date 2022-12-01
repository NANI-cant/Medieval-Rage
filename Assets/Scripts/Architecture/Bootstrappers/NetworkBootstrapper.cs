using Architecture.Services.Impl;
using Zenject;

namespace Architecture.Bootstrappers {
    public class NetworkBootstrapper: MonoInstaller {
        public override void InstallBindings() {
            BindService<NetworkStartup>();
            BindService<PhotonNetworkService>();
            BindService<ConnectionCallbacks>();
            BindService<NetworkInstantiateProvider>();
        }
        
        private void BindService<TService>() 
            => Container.BindInterfacesAndSelfTo<TService>().AsSingle().NonLazy();
    }
}