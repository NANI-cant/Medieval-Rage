using Gameplay.Player;
using Metrics;
using UnityEngine;

namespace Architecture.Services.Impl {
    public class GameplayFactory : IGameplayFactory {
        private readonly IPrefabProvider _prefabProvider;
        private readonly IInputService _inputService;
        private readonly IPlayerMetric _playerMetric;

        public GameplayFactory(
            IPrefabProvider prefabProvider,
            IMetricProvider metricProvider,
            IInputService inputService
        ) {
            _prefabProvider = prefabProvider;
            _inputService = inputService;
            _playerMetric = metricProvider.PlayerMetric;
        }

        public GameObject CreatePlayerCharacter(Vector3 position, Quaternion rotation) {
            var player = GameObject.Instantiate(_prefabProvider.PlayerCharacter, position, rotation);

            player.GetComponent<PlayerInputBrain>().Construct(_inputService);

            return player;
        }
    }

    public class UIFactory : IUIFactory {
        public GameObject CreateJoystickCanvas() {
            throw new System.NotImplementedException();
        }
    }
}
