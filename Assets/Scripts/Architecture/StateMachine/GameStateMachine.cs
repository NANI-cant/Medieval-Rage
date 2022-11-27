using System;
using System.Collections.Generic;
using Architecture.Services;
using Architecture.StateMachine.States;
using Gameplay.Setup;
using UnityEngine;

namespace Architecture.StateMachine {
    public class GameStateMachine : StateMachine{
        public GameStateMachine(IGameplayFactory gameplayFactory,
            Camera camera,
            IPlayerSpawner[] playerSpawners,
            ITraderSpawner[] traderSpawnPoints,
            IEnemySpawner[] enemySpawnPoints,
            IRandomService randomService,
            IResetUnitService resetUnitService) 
        {
            States = new Dictionary<Type, State> {
                [typeof(InitializationState)] = new InitializationState(this, gameplayFactory, randomService, resetUnitService, playerSpawners, enemySpawnPoints, traderSpawnPoints, camera),
                [typeof(GameLoopState)] = new GameLoopState(this),
            };

            TranslateTo<InitializationState>();
        }
    }
}