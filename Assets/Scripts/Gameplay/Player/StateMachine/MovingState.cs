using Architecture.StateMachine.States;
using Gameplay.Fighting;

namespace Gameplay.Player.StateMachine {
    public class MovingState : State {
        private readonly CharacterStateMachine _stateMachine;
        private readonly Mover _mover;
        private readonly AutoAttack _autoAttack;
        private readonly CharacterAnimator _animator;

        public MovingState(
            CharacterStateMachine stateMachine, 
            Mover mover,
            AutoAttack autoAttack,
            CharacterAnimator animator
            ) {
            _stateMachine = stateMachine;
            _mover = mover;
            _autoAttack = autoAttack;
            _animator = animator;
        }
        
        public override void Enter() {
            _autoAttack.TurnOff();
            _animator.Interrupt();
            _mover.Stopped += OnStopped;
        }

        public override void Exit() {
            _mover.Stopped -= OnStopped;
        }

        private void OnStopped() {
            _stateMachine.TranslateTo<IdleState>();
        }
    }
}