using Metrics;
using Metrics.Impl;
using UnityEngine;

namespace Architecture.Services.Impl {
    public class ResourcesMetricProvider : IMetricProvider {
        private const string PlayerMetricPath = "Metrics/PlayerMetric";
        private const string EnemyMetricPath = "Metrics/EnemyMetric";

        public IPlayerMetric PlayerMetric => Resources.Load<PlayerMetric>(PlayerMetricPath);
        public IEnemyMetric EnemyMetric => Resources.Load<EnemyMetric>(EnemyMetricPath);
    }
}
