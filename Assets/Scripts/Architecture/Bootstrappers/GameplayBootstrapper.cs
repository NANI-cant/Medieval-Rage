using Architecture.Services;
using InputLogic;
using UnityEngine;
using Zenject;

namespace Architecture.Bootstrappers {
    public class GameplayBootstrapper : MonoInstaller {
        [SerializeField] private UpdateContainer _updateContainer;
        [SerializeField] private Camera _mainCamera;

        private TouchInputService _inputService;

        public override void InstallBindings() {
            _inputService = new TouchInputService(_mainCamera);

            _updateContainer.Add(_inputService);

            Container.BindInstance<IInputService>(_inputService).AsSingle().NonLazy();
        }
    }
}
