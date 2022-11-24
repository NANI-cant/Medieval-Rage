using System;
using System.Collections.Generic;
using Architecture.StateMachine.States;
using Gameplay.Fighting;

namespace Gameplay.Enemy.StateMachine {
    public class EnemyStateMachine : Architecture.StateMachine.StateMachine {
        public EnemyStateMachine(AutoAttack autoAttack, AIMover mover, Aggro aggro) {
            States = new Dictionary<Type, State> {
                [typeof(CalmState)] = new CalmState(this, autoAttack, mover, aggro),
                [typeof(AggroState)] = new AggroState(this, autoAttack, mover, aggro),
            };
            
            TranslateTo<CalmState>();
        }

        public void Update() {
            if(ActiveState is IUpdatableState updatableState) updatableState.Update();
        }
    }
}