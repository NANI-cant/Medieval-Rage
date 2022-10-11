using Architecture.Services;
using Gameplay.Player;
using InputLogic;
using UnityEngine;
using Zenject;

namespace Architecture.Bootstrappers {
    public class GameplayBootstrapper : MonoInstaller {
        [SerializeField] private UpdateContainer _updateContainer;
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private LayerMask _touchableLayers;
        [SerializeField] private PlayerInputBrain _player;

        private TouchInputService _inputService;

        public override void InstallBindings() {
            _inputService = new TouchInputService(_mainCamera, _touchableLayers);

            _updateContainer.Add(_inputService);

            Container.BindInstance<PlayerInputBrain>(_player);
            Container.BindInstance<IInputService>(_inputService);
        }
    }
}
