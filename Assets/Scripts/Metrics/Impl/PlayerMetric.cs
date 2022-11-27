using Gameplay.Fighting;
using UnityEngine;

namespace Metrics.Impl {
    [CreateAssetMenu(fileName = "PlayerMetric", menuName = "Scriptable Objects/Player Metric")]
    public class PlayerMetric : ScriptableObject, IPlayerMetric {
        [Header("Health")] 
        [SerializeField] private float _maxHealth = 300f;
        [SerializeField] private int _attackTargetPriority;

        [Header("Movement")]
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _angularSpeed = 540f;

        [Header("Attack")]
        [SerializeField] private float _attackSpeed = 2f;
        [SerializeField] private float _attackRadius = 2f;
        [SerializeField] private AttackData _attackData;

        public float Speed => _speed;
        public float CoolDown => 1 / _attackSpeed;
        public float AttackSpeed => _attackSpeed;
        public float AngularSpeed => _angularSpeed;
        public int AttackTargetPriority => _attackTargetPriority;
        public float AttackRadius => _attackRadius;
        public float MaxHealth => _maxHealth;
        public AttackData AttackData => _attackData;
    }
}