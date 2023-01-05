using Zenject;
using Lobby;

namespace Architecture.Bootstrappers {
    public class LobbyBootstrapper : MonoInstaller {
        public override void InstallBindings() {
            BindService<LobbyModel>();
        }
        
        private void BindService<TService>() 
            => Container.BindInterfacesAndSelfTo<TService>().AsSingle().NonLazy();
    }
}