using Architecture.Services;
using CameraLogic;
using Gameplay.Setup;
using UnityEngine;

namespace Architecture.StateMachine.States {
    public class InitializationState : State {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IGameplayFactory _gameplayFactory;
        private readonly IRandomService _randomService;
        private readonly IPlayerSpawnPoint _playerSpawnPoint;
        private readonly IEnemySpawnPoint[] _enemySpawnPoints;
        private readonly ITraderSpawnPoint[] _traderSpawnPoints;
        private readonly Camera _camera;

        public InitializationState(
            GameStateMachine gameStateMachine,
            IGameplayFactory gameplayFactory,
            IRandomService randomService,
            IPlayerSpawnPoint playerSpawnPoint,
            IEnemySpawnPoint[] enemySpawnPoints,
            ITraderSpawnPoint[] traderSpawnPoints,
            Camera camera
        ) {
            _gameStateMachine = gameStateMachine;
            _gameplayFactory = gameplayFactory;
            _randomService = randomService;
            _playerSpawnPoint = playerSpawnPoint;
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

        private GameObject SpawnPlayer() 
            => _gameplayFactory.CreatePlayerCharacter(_playerSpawnPoint.Position, _playerSpawnPoint.Rotation);

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