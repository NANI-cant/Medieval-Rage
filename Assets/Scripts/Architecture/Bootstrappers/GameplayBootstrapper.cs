using Architecture.Services.Factories.Impl;
using Architecture.Services.Gameplay.Impl;
using Architecture.Services.General.Impl;
using Architecture.Services.Impl;
using Architecture.Services.Network;
using Architecture.Services.Teaming.Impl;
using Architecture.StateMachine;
using UnityEngine;
using Zenject;

namespace Architecture.Bootstrappers {
    public class GameplayBootstrapper: MonoInstaller {
        [SerializeField] private Joystick _joystick;
        private INetworkService _networkService;

        [Inject]
        public void PullDependencies(INetworkService networkService) {
            _networkService = networkService;
        }

        public override void InstallBindings()
        {
            Container.Bind<Joystick>().FromInstance(_joystick).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<JoystickInputService>().AsSingle().NonLazy();
            Container.Bind<Camera>().FromInstance(Camera.main).AsSingle().NonLazy();
            
            BindService<RandomService>();
            BindService<GameplayFactory>();
            BindService<UIFactory>();
            BindService<GameStateMachine>();
            BindService<SpawnEnemiesService>();
            BindService<TeamProvider>();

            if (_networkService.IsMaster) {
                BindService<GameClock>();    
            }
            else {
                BindService<NetworkGameClock>();
            }
        }

        private void BindService<TService>() 
			=> Container.BindInterfacesAndSelfTo<TService>().AsSingle().NonLazy();
    }    
}
