using UnityEngine;

namespace Metrics {
    [CreateAssetMenu(fileName = "PlayerMetric", menuName = "ScriptableObjects/PlayerMetric")]
    public class PlayerMetric : ScriptableObject {
        [SerializeField] private float _speed = 5f;

        public float Speed => _speed;
    }
}