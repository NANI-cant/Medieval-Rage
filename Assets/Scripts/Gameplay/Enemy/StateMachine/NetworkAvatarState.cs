using Architecture.StateMachine.States;
using Gameplay.Fighting;

namespace Gameplay.Enemy.StateMachine {
    public class NetworkAvatarState: State {
        private readonly EnemyStateMachine _enemyStateMachine;
        private readonly AutoAttack _autoAttack;
        private readonly Aggro _aggro;

        public NetworkAvatarState(
            EnemyStateMachine enemyStateMachine,
            AutoAttack autoAttack,
            Aggro aggro
        ) {
            _enemyStateMachine = enemyStateMachine;
            _autoAttack = autoAttack;
            _aggro = aggro;
        }

        public override void Enter() {
            _autoAttack.TurnOff();
            _aggro.TurnOff();
        }
    }
}