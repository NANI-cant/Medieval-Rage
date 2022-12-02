using Architecture.Services.General.Impl;
using Architecture.Services.Impl;
using Architecture.Services.Teaming.Impl;
using Architecture.StateMachine;
using UnityEngine;
using Zenject;

namespace Architecture.Bootstrappers {
    public class GameplayBootstrapper : MonoInstaller
    {
        [SerializeField] private Joystick _joystick;

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
            BindService<GameClock>();
            BindService<TeamProvider>();
        }

        private void BindService<TService>() 
			=> Container.BindInterfacesAndSelfTo<TService>().AsSingle().NonLazy();
    }    
}
