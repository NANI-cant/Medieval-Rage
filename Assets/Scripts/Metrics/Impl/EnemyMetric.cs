using Gameplay.Fighting;
using UnityEngine;

namespace Metrics.Impl {
    [CreateAssetMenu(fileName = "EnemyMetric", menuName = "Scriptable Objects/Enemy Metric")]
    public class EnemyMetric: ScriptableObject, IEnemyMetric {
        [SerializeField] private float _maxHealth = 100f;
        [SerializeField] private float _speed = 3f;
        [SerializeField] private int _attackTargetPriority;
        [SerializeField] private float _aggroDuration = 5f;
        [SerializeField] private float _attackSpeed = 1f;
        [SerializeField] private AttackData _attackData;

        public float MaxHealth => _maxHealth;
        public float Speed => _speed;
        public float AggroDuration => _aggroDuration;
        public float AttackCooldown => 1 / _attackSpeed;
        public int AttackTargetPriority => _attackTargetPriority;
        public float AttackSpeed => _attackSpeed;
        public AttackData AttackData => _attackData;
    }
}