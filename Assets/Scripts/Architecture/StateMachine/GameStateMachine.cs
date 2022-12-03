using System;
using System.Collections.Generic;
using Architecture.Services.Factories;
using Architecture.Services.Gameplay;
using Architecture.Services.General;
using Architecture.StateMachine.States;
using Gameplay.Setup;
using UnityEngine;
using Zenject;

namespace Architecture.StateMachine {
    public class GameStateMachine : StateMachine, IInitializable{
        public GameStateMachine(IGameplayFactory gameplayFactory,
            Camera camera,
            IPlayerSpawner[] playerSpawners,
            ITraderSpawner[] traderSpawnPoints,
            IRandomService randomService,
            IGameClock gameClock,
            ISpawnEnemiesService spawnEnemiesService, 
            IUIFactory uiFactory) 
        {
            States = new Dictionary<Type, State> {
                [typeof(InitializationState)] = new InitializationState(this, gameplayFactory, uiFactory, randomService, gameClock, playerSpawners, traderSpawnPoints, camera),
                [typeof(GameLoopState)] = new GameLoopState(this, spawnEnemiesService, gameClock),
            };
        }

        public void Initialize() {
            TranslateTo<InitializationState>();
        }
    }
}