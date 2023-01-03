using Architecture.StateMachine.States;
using Gameplay.Fighting;

namespace Gameplay.Enemy.StateMachine {
    public class NetworkAvatarState: State {
        private readonly EnemyStateMachine _enemyStateMachine;
        private readonly AutoAttack _autoAttack;
        private readonly AIMover _mover;
        private readonly Aggro _aggro;

        public NetworkAvatarState(
            EnemyStateMachine enemyStateMachine,
            AutoAttack autoAttack,
            AIMover mover,
            Aggro aggro
        ) {
            _enemyStateMachine = enemyStateMachine;
            _autoAttack = autoAttack;
            _mover = mover;
            _aggro = aggro;
        }

        public override void Enter() {
            _autoAttack.TurnOff();
            _mover.enabled = false;
            _aggro.TurnOff();
        }
    }
}