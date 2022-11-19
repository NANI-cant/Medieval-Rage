using UnityEngine;

namespace Metrics.Impl {
    [CreateAssetMenu(fileName = "PlayerMetric", menuName = "ScriptableObjects/PlayerMetric")]
    public class PlayerMetric : ScriptableObject, IPlayerMetric {
        [SerializeField] private float _speed = 5f;

        public float Speed => _speed;
    }
}