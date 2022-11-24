using System;
using System.Collections.Generic;
using Architecture.StateMachine.States;

namespace Architecture.StateMachine {
    public abstract class StateMachine {
        protected Dictionary<Type, State> States;
        
        protected State ActiveState { get; private set; }

        public void TranslateTo<TState>() where TState : State {
            ActiveState?.Exit();
            ActiveState = States[typeof(TState)];
            ActiveState?.Enter();
        }
    }
}