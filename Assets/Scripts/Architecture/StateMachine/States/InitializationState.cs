using Architecture.Services;
using Architecture.Services.General;
using CameraLogic;
using Gameplay.Setup;
using UnityEngine;

namespace Architecture.StateMachine.States {
    public class InitializationState : State {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IGameplayFactory _gameplayFactory;
        private readonly IUIFactory _uiFactory;
        private readonly IRandomService _randomService;
        private readonly IGameClock _gameClock;
        private readonly IPlayerSpawner[] _playerSpawners;
        private readonly ITraderSpawner[] _traderSpawnPoints;
        private readonly Camera _camera;

        public InitializationState(
            GameStateMachine gameStateMachine,
            IGameplayFactory gameplayFactory,
            IUIFactory uiFactory,
            IRandomService randomService,
            IGameClock gameClock,
            IPlayerSpawner[] playerSpawners,
            ITraderSpawner[] traderSpawnPoints,
            Camera camera
        ) {
            _gameStateMachine = gameStateMachine;
            _gameplayFactory = gameplayFactory;
            _uiFactory = uiFactory;
            _randomService = randomService;
            _gameClock = gameClock;
            _playerSpawners = playerSpawners;
            _traderSpawnPoints = traderSpawnPoints;
            _camera = camera;
        }

        public override void Enter() {
            var player = SpawnPlayer();
            SetupCamera(player);
            SpawnTraders();
            _uiFactory.CreateHUD();
            _gameClock.Start();

            _gameStateMachine.TranslateTo<GameLoopState>();
        }

        private GameObject SpawnPlayer() {
            var randomIndex = _randomService.Range(0, _playerSpawners.Length);
            var pickedSpawner = _playerSpawners[randomIndex];
            var player = _gameplayFactory.CreatePlayerCharacter(pickedSpawner.Position, pickedSpawner.Rotation);
            pickedSpawner.TrackPlayer(player);
            return player;
        }

        private void SpawnTraders() {
            
        }

        private void SetupCamera(GameObject player) {
            if (_camera.TryGetComponent<Following>(out var following)) {
                following.Follow(player.transform);
            }
            else {
                _camera.gameObject.AddComponent<Following>().Follow(player.transform);
            }
        }
    }
}