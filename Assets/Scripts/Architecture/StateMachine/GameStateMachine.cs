using System;
using System.Collections.Generic;
using Architecture.Services.Factories;
using Architecture.Services.Gameplay;
using Architecture.Services.Gameplay.Impl;
using Architecture.Services.General;
using Architecture.Services.Network;
using Architecture.Services.Network.Impl;
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
            IUIFactory uiFactory,
            IBossSpawner bossSpawner,
            IInputService inputService,
            INetworkService networkService,
            RoomService roomService,
            GameNetEventsService gameNetEventsService,
            NetworkGameplayFactory networkGameplayFactory, 
            SpawnEnemiesAvatarsService spawnEnemiesAvatarsService) 
        {
            States = new Dictionary<Type, State> {
                [typeof(InitializationState)] = new InitializationState(this, gameplayFactory, uiFactory, randomService, gameClock, playerSpawners, traderSpawnPoints, camera, networkService, gameNetEventsService),
                [typeof(GameLoopState)] = new GameLoopState(this, spawnEnemiesService, bossSpawner, gameClock, gameNetEventsService),
                [typeof(PassiveNetGameLoopState)] = new PassiveNetGameLoopState(this, roomService, gameNetEventsService, networkGameplayFactory, spawnEnemiesAvatarsService),
                [typeof(GameEndState)] = new GameEndState(this, gameClock, uiFactory, inputService),
            };
        }

        public void Initialize() => TranslateTo<InitializationState>();
    }
}