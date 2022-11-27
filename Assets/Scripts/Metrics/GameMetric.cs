using UnityEngine;

namespace Metrics {
    [CreateAssetMenu(menuName = "Metric/Game Metric", fileName = "GameMetric")]
    public class GameMetric: ScriptableObject {
        [SerializeField] private int _seed;

        public int Seed => _seed;
    }
}