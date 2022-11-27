using Architecture.Services;
using CameraLogic;
using Gameplay.Setup;
using UnityEngine;

namespace Architecture.StateMachine.States {
    public class InitializationState : State {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IGameplayFactory _gameplayFactory;
        private readonly IRandomService _randomService;
        private readonly IResetUnitService _resetUnitService;
        private readonly IPlayerSpawner[] _playerSpawners;
        private readonly IEnemySpawner[] _enemySpawnPoints;
        private readonly ITraderSpawner[] _traderSpawnPoints;
        private readonly Camera _camera;

        public InitializationState(
            GameStateMachine gameStateMachine,
            IGameplayFactory gameplayFactory,
            IRandomService randomService,
            IResetUnitService resetUnitService,
            IPlayerSpawner[] playerSpawners,
            IEnemySpawner[] enemySpawnPoints,
            ITraderSpawner[] traderSpawnPoints,
            Camera camera
        ) {
            _gameStateMachine = gameStateMachine;
            _gameplayFactory = gameplayFactory;
            _randomService = randomService;
            _resetUnitService = resetUnitService;
            _playerSpawners = playerSpawners;
            _enemySpawnPoints = enemySpawnPoints;
            _traderSpawnPoints = traderSpawnPoints;
            _camera = camera;
        }

        public override void Enter() {
            var player = SpawnPlayer();
            SpawnEnemies();
            SetupCamera(player);
            
            _gameStateMachine.TranslateTo<GameLoopState>();
        }

        private GameObject SpawnPlayer() {
            var randomIndex = _randomService.Range(0, _playerSpawners.Length);
            var pickedSpawner = _playerSpawners[randomIndex];
            var player = _gameplayFactory.CreatePlayerCharacter(pickedSpawner.Position, pickedSpawner.Rotation);
            pickedSpawner.TrackPlayer(player, _resetUnitService);
            return player;
        }

        private void SetupCamera(GameObject player) {
            if (_camera.TryGetComponent<Following>(out var following)) {
                following.Follow(player.transform);
            }
            else {
                _camera.gameObject.AddComponent<Following>().Follow(player.transform);
            }
        }

        private void SpawnEnemies() {
            foreach (var spawner in _enemySpawnPoints) {
                EnemyPack[] allPacks = spawner.Packs;
                var randomIndex = _randomService.Range(0, allPacks.Length);
                var pack = allPacks[randomIndex];

                foreach (var enemyId in pack.Enemies) {
                    _gameplayFactory.CreateEnemy(enemyId, spawner.Position, spawner.Rotation);
                }
            }
        }
    }
}