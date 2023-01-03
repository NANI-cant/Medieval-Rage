using Architecture.StateMachine.States;
using Gameplay.Fighting;
using UnityEngine;

namespace Gameplay.Enemy.StateMachine {
    public class CalmState : State {
        private readonly EnemyStateMachine _stateMachine;
        private readonly AutoAttack _autoAttack;
        private readonly AIMover _mover;
        private readonly Aggro _aggro;

        public CalmState(
            EnemyStateMachine stateMachine,
            AutoAttack autoAttack,
            AIMover mover,
            Aggro aggro
        ) {
            _stateMachine = stateMachine;
            _autoAttack = autoAttack;
            _mover = mover;
            _aggro = aggro;
        }

        public override void Enter() {
            Debug.Log("Calm");
            _autoAttack.TurnOff();
            _aggro.TurnOff();
            _mover.ReturnToSpawn();
            
            _mover.ReturnedToSpawn += TurnOnAggro;
            _aggro.Aggrieved += GetAggressive;
        }

        public override void Exit() {
            _mover.ReturnedToSpawn -= TurnOnAggro;
            _aggro.Aggrieved -= GetAggressive;
        }

        private void GetAggressive() {
            _stateMachine.TranslateTo<AggroState>();
        }

        private void TurnOnAggro() {
            _aggro.TurnOn();
        }
    }
}