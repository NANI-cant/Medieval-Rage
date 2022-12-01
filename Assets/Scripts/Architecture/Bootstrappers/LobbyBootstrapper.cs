using UI.Lobby;
using UnityEngine;
using Zenject;

namespace Architecture.Bootstrappers {
    public class LobbyBootstrapper : MonoInstaller {
        [SerializeField] private LobbyView _lobbyView;
        
        public override void InstallBindings() {
            BindService<Lobby.LobbyModel>();
        }
        
        private void BindService<TService>() 
            => Container.BindInterfacesAndSelfTo<TService>().AsSingle().NonLazy();
    }
}