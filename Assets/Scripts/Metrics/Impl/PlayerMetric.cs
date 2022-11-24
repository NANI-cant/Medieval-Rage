using Gameplay.Fighting;
using UnityEngine;

namespace Metrics.Impl {
    [CreateAssetMenu(fileName = "PlayerMetric", menuName = "Scriptable Objects/Player Metric")]
    public class PlayerMetric : ScriptableObject, IPlayerMetric {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _angularSpeed = 540f;
        [SerializeField] private int _attackTargetPriority;
        [SerializeField] private float _attackSpeed = 2f;
        [SerializeField] private AttackData _attackData;

        public float Speed => _speed;
        public float CoolDown => 1 / _attackSpeed;
        public float AttackSpeed => _attackSpeed;
        public float AngularSpeed => _angularSpeed;
        public int AttackTargetPriority => _attackTargetPriority;
        public AttackData AttackData => _attackData;
    }
}