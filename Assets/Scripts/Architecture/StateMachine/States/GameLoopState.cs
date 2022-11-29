using System;
using Architecture.Services;
using Gameplay.Setup;

namespace Architecture.StateMachine.States {
    public class GameLoopState : State {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ISpawnEnemiesService _spawnEnemiesService;
        private readonly IGameClock _gameClock;

        public GameLoopState(
            GameStateMachine gameStateMachine,
            ISpawnEnemiesService spawnEnemiesService,
            IGameClock gameClock) 
        {
            _gameStateMachine = gameStateMachine;
            _spawnEnemiesService = spawnEnemiesService;
            _gameClock = gameClock;
        }

        public override void Enter() {
            _gameClock.EnemiesShouldSpawn += SpawnEnemies;
        }

        public override void Exit() {
            _gameClock.EnemiesShouldSpawn -= SpawnEnemies;
        }

        private void SpawnEnemies() {
            _spawnEnemiesService.Spawn();
        }
    }
}