using Architecture.Services.Gameplay;
using Gameplay.Setup;

namespace Architecture.StateMachine.States {
    public class GameLoopState : State {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ISpawnEnemiesService _spawnEnemiesService;
        private readonly IBossSpawner _bossSpawner;
        private readonly IGameClock _gameClock;

        public GameLoopState(
            GameStateMachine gameStateMachine,
            ISpawnEnemiesService spawnEnemiesService,
            IBossSpawner bossSpawner,
            IGameClock gameClock) 
        {
            _gameStateMachine = gameStateMachine;
            _spawnEnemiesService = spawnEnemiesService;
            _bossSpawner = bossSpawner;
            _gameClock = gameClock;
        }

        public override void Enter() {
            _gameClock.EnemiesShouldSpawn += SpawnEnemies;
            _gameClock.BossShouldSpawn += SpawnBoss;
            _bossSpawner.Slayed += EndGame;
        }

        public override void Exit() {
            _gameClock.EnemiesShouldSpawn -= SpawnEnemies;
            _gameClock.BossShouldSpawn -= SpawnBoss;
            _bossSpawner.Slayed -= EndGame;
        }

        private void EndGame() => _gameStateMachine.TranslateTo<GameEndState>();
        private void SpawnBoss() => _spawnEnemiesService.SpawnBoss();
        private void SpawnEnemies() => _spawnEnemiesService.Spawn();
    }
}