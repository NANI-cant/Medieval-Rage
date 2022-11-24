using UnityEngine;

namespace Gameplay.Fighting {
    public class AttackTarget {
        public IDamageable Damageable { get; }
        public int Priority { get; }
        public Transform Transform { get; }

        public AttackTarget(IDamageable damageable, int priority, Transform transform) {
            Damageable = damageable;
            Priority = priority;
            Transform = transform;
        }
    }
}