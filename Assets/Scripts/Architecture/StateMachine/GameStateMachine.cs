using System;
using System.Collections.Generic;
using Architecture.Services;
using Architecture.StateMachine.States;
using UnityEngine;

namespace Architecture {
    public class GameStateMachine {
        private Dictionary<Type, State> _states;
        private State _activeState;

        public GameStateMachine(
            IGameplayFactory gameplayFactory,
            Camera camera
        ) {
            _states = new Dictionary<Type, State> {
                [typeof(InitializationState)] = new InitializationState(this, gameplayFactory, camera),
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