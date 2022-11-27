using System;
using Gameplay.Fighting;
using UnityEngine;

namespace Metrics {
    public interface IEnemyMetric {
        float MaxHealth { get; }
        float Speed { get; }
        float AggroRadius { get; }
        float AggroDuration { get; }
        float AttackCooldown { get; }
        int AttackTargetPriority { get; }
        float AttackSpeed { get; }
        float AngularSpeed { get; }
        float AttackRadius { get; }
        AttackData AttackData { get; }
    }
}