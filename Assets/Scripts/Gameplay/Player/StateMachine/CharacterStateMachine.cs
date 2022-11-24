using System;
using System.Collections.Generic;
using Architecture.StateMachine.States;
using Gameplay.Fighting;

namespace Gameplay.Player.StateMachine {
    public class CharacterStateMachine: Architecture.StateMachine.StateMachine {
        public CharacterStateMachine(CharacterAnimator animator,
            AutoAttack autoAttack,
            Mover mover, 
            Rotator rotator
            ) {
            States = new Dictionary<Type, State> {
                [typeof(IdleState)] = new IdleState(this, animator, autoAttack, mover, rotator),
                [typeof(MovingState)] = new MovingState(this, mover, autoAttack, animator),
            };
            
            TranslateTo<IdleState>();
        }

        public void Update() {
            if(ActiveState is IUpdatableState updatableState) updatableState.Update();
        }
    }
}