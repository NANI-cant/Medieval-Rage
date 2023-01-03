using System;
using System.Collections.Generic;
using Architecture.StateMachine.States;
using Gameplay.Fighting;

namespace Gameplay.Enemy.StateMachine {
    public class EnemyStateMachine : Architecture.StateMachine.StateMachine {
        public EnemyStateMachine(
            AutoAttack autoAttack, 
            AIMover mover, 
            Aggro aggro,
            EnemyAnimator animator
            ) {
            States = new Dictionary<Type, State> {
                [typeof(NetworkAvatarState)] = new NetworkAvatarState(this, autoAttack, aggro),
                [typeof(CalmState)] = new CalmState(this, autoAttack, mover, aggro),
                [typeof(AggroState)] = new AggroState(this, autoAttack, mover, aggro, animator),
            };
        }
    }
}