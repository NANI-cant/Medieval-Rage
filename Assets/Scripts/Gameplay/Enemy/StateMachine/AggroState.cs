using Architecture.StateMachine.States;
using Gameplay.Fighting;

namespace Gameplay.Enemy.StateMachine {
    public class AggroState : State {
        private readonly EnemyStateMachine _stateMachine;
        private readonly AutoAttack _autoAttack;
        private readonly AIMover _mover;
        private readonly Aggro _aggro;
        private readonly EnemyAnimator _animator;

        public AggroState(EnemyStateMachine stateMachine,
            AutoAttack autoAttack,
            AIMover mover,
            Aggro aggro, 
            EnemyAnimator animator
            ) {
            _stateMachine = stateMachine;
            _autoAttack = autoAttack;
            _mover = mover;
            _aggro = aggro;
            _animator = animator;
        }

        public override void Enter() {
            _autoAttack.TargetCaptured += Fight;
            _autoAttack.TargetLost += Approach;
            _aggro.CalmedDown += CalmDown;
            _autoAttack.Swung += _animator.PlayAttack;

            if (_autoAttack.Target != null) {
                Fight();
            }
            else {
                Approach();
            }
        }

        public override void Exit() {
            _autoAttack.TurnOff();
            _aggro.TurnOff();
            _animator.Interrupt();

            _autoAttack.TargetCaptured -= Fight;
            _autoAttack.TargetLost -= Approach;
            _aggro.CalmedDown -= CalmDown;
            _autoAttack.Swung -= _animator.PlayAttack;
        }

        private void CalmDown() {
            _stateMachine.TranslateTo<CalmState>();
        }

        private void Fight() {
            _mover.Stop();
            _aggro.TurnOff();
            _autoAttack.TurnOn();
        }

        private void Approach() {
            _animator.Interrupt();
            _autoAttack.TurnOff();
            _aggro.TurnOn();
        }
    }
}