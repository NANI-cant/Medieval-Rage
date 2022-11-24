using Architecture.StateMachine.States;
using Gameplay.Fighting;

namespace Gameplay.Player.StateMachine {
    public class IdleState : State, IUpdatableState {
        private readonly CharacterStateMachine _stateMachine;
        private readonly CharacterAnimator _animator;
        private readonly AutoAttack _autoAttack;
        private readonly Mover _mover;
        private readonly Rotator _rotator;

        public IdleState(
            CharacterStateMachine stateMachine,
            CharacterAnimator animator,
            AutoAttack autoAttack,
            Mover mover,
            Rotator rotator
            ) {
            _stateMachine = stateMachine;
            _animator = animator;
            _autoAttack = autoAttack;
            _mover = mover;
            _rotator = rotator;
        }

        public override void Enter() {
            _autoAttack.Swung += OnSwung;
            _mover.Started += OnStarted;
            
            _autoAttack.TurnOn();
        }

        public override void Exit() {
            _autoAttack.Swung -= OnSwung;
            _mover.Started += OnStarted;
        }

        public void Update() {
            var attackTarget = _autoAttack.Target;
            if(attackTarget == null) return;
            
            _rotator.RotateTo(attackTarget.Transform.position);
        }

        private void OnStarted() {
            _stateMachine.TranslateTo<MovingState>();
        }

        private void OnSwung() {
            _animator.PlayAttack();
        }
    }
}