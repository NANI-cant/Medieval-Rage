using Architecture.Services.Impl;
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

            BindService<GameplayFactory>();
            BindService<GameStateMachine>();
        }

        private void BindService<TService>() 
			=> Container.BindInterfacesAndSelfTo<TService>().AsSingle().NonLazy();
    }    
}
