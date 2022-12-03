using Gameplay.Fighting;

namespace Gameplay.Health {
    public interface IHealth: IDamageable {
        float MaxHealth { get; }
        float CurrentHealth { get; }
    }
}