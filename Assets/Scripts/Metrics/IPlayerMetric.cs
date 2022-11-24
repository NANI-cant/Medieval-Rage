using Gameplay.Fighting;

namespace Metrics {
    public interface IPlayerMetric {
        float Speed { get; }
        float CoolDown { get;}
        float AttackSpeed { get;}
        float AngularSpeed { get;}
        int AttackTargetPriority { get;}
        AttackData AttackData { get;}
    }
}
