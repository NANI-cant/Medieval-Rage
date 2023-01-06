using Architecture.Services.Gameplay.Impl;
using Architecture.Services.Network.Impl;

namespace Architecture.StateMachine.States {
    public class PassiveNetGameLoopState : State {
        private readonly GameStateMachine _gameStateMachine;
        private readonly RoomService _roomService;
        private readonly GameNetEventsService _gameNetEventsService;
        private readonly NetworkGameplayFactory _networkGameplayFactory;
        private readonly SpawnEnemiesAvatarsService _spawnEnemiesAvatarsService;

        public PassiveNetGameLoopState(
            GameStateMachine gameStateMachine, 
            RoomService roomService,
            GameNetEventsService gameNetEventsService,
            NetworkGameplayFactory networkGameplayFactory,
            SpawnEnemiesAvatarsService spawnEnemiesAvatarsService
        ) {
            _gameStateMachine = gameStateMachine;
            _roomService = roomService;
            _gameNetEventsService = gameNetEventsService;
            _networkGameplayFactory = networkGameplayFactory;
            _spawnEnemiesAvatarsService = spawnEnemiesAvatarsService;
        }

        public override void Enter() {
            _roomService.IAmMasterNow += TranslateToMasterGameLoop;
            _gameNetEventsService.GameEnded += TranslateToGameEnd;
            _gameNetEventsService.EnemySpawned += SpawnEnemyAvatar;
        }

        public override void Exit() {
            _roomService.IAmMasterNow -= TranslateToMasterGameLoop;
            _gameNetEventsService.GameEnded -= TranslateToGameEnd;
            _gameNetEventsService.EnemySpawned -= SpawnEnemyAvatar;
        }

        private void SpawnEnemyAvatar(EnemyNetSpawnData enemyNetSpawnData) => _spawnEnemiesAvatarsService.SpawnEnemy(enemyNetSpawnData);
        private void TranslateToGameEnd() => _gameStateMachine.TranslateTo<GameEndState>();
        private void TranslateToMasterGameLoop() => _gameStateMachine.TranslateTo<GameLoopState>();
    }
}