using Gameplay.Fighting;

namespace Metrics {
    public interface IEnemyMetric {
        float MaxHealth { get; }
        float Speed { get; }
        float AggroDuration { get; }
        float AttackCooldown { get; }
        int AttackTargetPriority { get; }
        AttackData AttackData { get; }
    }
}