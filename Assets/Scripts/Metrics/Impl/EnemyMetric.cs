using UnityEngine;

namespace Metrics.Impl {
    [CreateAssetMenu(fileName = "EnemyMetric", menuName = "Scriptable Objects/Enemy Metric")]
    public class EnemyMetric: ScriptableObject, IEnemyMetric {
        [SerializeField] private float _speed = 3f;
        [SerializeField] private float _aggroDuration = 5f;

        public float Speed => _speed;
        public float AggroDuration => _aggroDuration;
    }
}