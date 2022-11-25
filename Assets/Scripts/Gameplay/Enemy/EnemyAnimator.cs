using Architecture.Services;
using Gameplay.Player;

namespace Gameplay.Enemy {
    public class EnemyAnimator : CharacterAnimator {
        public override void Construct(float attackSpeed, IRandomService randomService) {
            base.Construct(attackSpeed, randomService);
            AttackStates = new string[] {
                "Attack1",
                "Attack2"
            };
        }
    }
}