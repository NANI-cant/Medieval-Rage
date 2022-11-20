using UnityEngine;

namespace Metrics.Impl {
    [CreateAssetMenu(fileName = "PlayerMetric", menuName = "Scriptable Objects/Player Metric")]
    public class PlayerMetric : ScriptableObject, IPlayerMetric {
        [SerializeField] private float _speed = 5f;

        public float Speed => _speed;
    }
}