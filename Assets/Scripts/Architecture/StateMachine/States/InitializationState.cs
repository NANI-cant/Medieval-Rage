using Architecture.Services;
using CameraLogic;
using UnityEngine;

namespace Architecture.StateMachine.States {
    public class InitializationState : State {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IGameplayFactory _gameplayFactory;
        private readonly Camera _camera;

        public InitializationState(
            GameStateMachine gameStateMachine,
            IGameplayFactory gameplayFactory,
            Camera camera
        ) {
            _gameStateMachine = gameStateMachine;
            _gameplayFactory = gameplayFactory;
            _camera = camera;
        }

        public override void Enter() {
            var player = _gameplayFactory.CreatePlayerCharacter(Vector3.zero, Quaternion.identity);

            if (_camera.TryGetComponent<Following>(out var following)) {
                following.Follow(player.transform);
            }
            else {
                _camera.gameObject.AddComponent<Following>().Follow(player.transform);
            }

            _gameStateMachine.TranslateTo<GameLoopState>();
        }
    }
}