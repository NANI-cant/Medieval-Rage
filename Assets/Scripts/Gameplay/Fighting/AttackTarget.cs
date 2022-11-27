using System;
using UnityEngine;

namespace Gameplay.Fighting {
    [Serializable]
    public class AttackTarget {
        [SerializeField] private Transform _transform;
        [SerializeField] private int _priority;
        
        public IDamageable Damageable { get; }
        public int Priority { get; }
        public Transform Transform { get; }

        public AttackTarget(IDamageable damageable, int priority, Transform transform) {
            Damageable = damageable;
            Priority = priority;
            Transform = transform;
            
            _transform = Transform;
            _priority = Priority;
        }

        public override bool Equals(object obj) 
            => (obj as AttackTarget).Damageable == Damageable;
    }
}