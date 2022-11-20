using System;
using System.Collections.Generic;
using Architecture.Services;
using Architecture.StateMachine.States;
using Gameplay.Setup;
using UnityEngine;

namespace Architecture.StateMachine {
    public class GameStateMachine {
        private Dictionary<Type, State> _states;
        private State _activeState;

        public GameStateMachine(
            IGameplayFactory gameplayFactory,
            Camera camera,
            IPlayerSpawnPoint playerSpawnPoint,
            ITraderSpawnPoint[] traderSpawnPoints,
            IEnemySpawnPoint[] enemySpawnPoints, 
            IRandomService randomService) 
        {
            _states = new Dictionary<Type, State> {
                [typeof(InitializationState)] = new InitializationState(this, gameplayFactory,randomService, playerSpawnPoint, enemySpawnPoints, traderSpawnPoints, camera),
                [typeof(GameLoopState)] = new GameLoopState(this),
            };

            TranslateTo<InitializationState>();
        }

        public void TranslateTo<TState>() where TState : State {
            _activeState?.Exit();
            _activeState = _states[typeof(TState)];
            _activeState?.Enter();
        }
    }
}