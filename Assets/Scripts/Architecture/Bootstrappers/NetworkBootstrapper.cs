using Architecture.Services.Network;
using Architecture.Services.Network.Impl;
using Zenject;

namespace Architecture.Bootstrappers {
    public class NetworkBootstrapper: MonoInstaller {
        public override void InstallBindings() {
            BindService<PhotonNetworkService>();
            BindService<ConnectionService>();
            BindService<RoomService>();
            BindService<MatchmakingService>();
            BindService<LobbyService>();
        }
        
        private void BindService<TService>() 
            => Container.BindInterfacesAndSelfTo<TService>().AsSingle().NonLazy();
    }
}