using Gameplay.Fighting;
using UnityEngine;

namespace Metrics.Impl {
    [CreateAssetMenu(fileName = "EnemyMetric", menuName = "Scriptable Objects/Enemy Metric")]
    public class EnemyMetric: ScriptableObject, IEnemyMetric {
        [Header("Health")]
        [SerializeField] private float _maxHealth = 100f;
        [SerializeField] private int _attackTargetPriority;

        [Header("Movement")]
        [SerializeField] private float _speed = 3f;
        [SerializeField] private float _angularSpeed = 720f;

        [Header("Aggro")]
        [SerializeField] private float _aggroRadius = 1.5f;
        [SerializeField] private float _aggroDuration = 5f;
        
        [Header("Attack")]
        [SerializeField] private float _attackSpeed = 1f;
        [SerializeField] private float _attackRadius = 2f;
        [SerializeField] private AttackData _attackData;

        public float MaxHealth => _maxHealth;
        public float Speed => _speed;
        public float AggroRadius => _aggroRadius;
        public float AggroDuration => _aggroDuration;
        public float AttackCooldown => 1 / _attackSpeed;
        public int AttackTargetPriority => _attackTargetPriority;
        public float AttackSpeed => _attackSpeed;
        public float AngularSpeed => _angularSpeed;
        public float AttackRadius => _attackRadius;
        public AttackData AttackData => _attackData;
    }
}