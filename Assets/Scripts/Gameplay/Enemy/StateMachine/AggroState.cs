using Architecture.StateMachine.States;
using Gameplay.Fighting;
using UnityEngine;

namespace Gameplay.Enemy.StateMachine {
    public class AggroState : State {
        private readonly EnemyStateMachine _stateMachine;
        private readonly AutoAttack _autoAttack;
        private readonly AIMover _mover;
        private readonly Aggro _aggro;

        public AggroState(
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
            Debug.Log("Aggro State");
            _autoAttack.TargetCaptured += Fight;
            _autoAttack.TargetLost += Approach;
            _aggro.CalmedDown += CalmDown;

            if (_autoAttack.Target != null) {
                Fight();
            }
            else {
                Approach();
            }
        }

        public override void Exit() {
            _autoAttack.TurnOff();

            _autoAttack.TargetCaptured -= Fight;
            _autoAttack.TargetLost -= Approach;
            _aggro.CalmedDown -= CalmDown;
        }

        private void CalmDown() {
            _stateMachine.TranslateTo<CalmState>();
        }

        private void Fight() {
            _aggro.TurnOff();
            _autoAttack.TurnOn();
        }

        private void Approach() {
            _autoAttack.TurnOff();
            _aggro.TurnOn();
        }
    }
}