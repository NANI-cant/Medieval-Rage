using Architecture.Services.Network.Impl;
using Zenject;

namespace Architecture.Bootstrappers {
    public class NetworkBootstrapper: MonoInstaller {
        public override void InstallBindings() {
            BindService<NetworkStartup>();
            BindService<PhotonNetworkService>();
            BindService<ConnectionCallbacks>();
        }
        
        private void BindService<TService>() 
            => Container.BindInterfacesAndSelfTo<TService>().AsSingle().NonLazy();
    }
}