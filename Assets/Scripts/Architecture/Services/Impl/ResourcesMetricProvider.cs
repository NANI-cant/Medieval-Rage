using Gameplay.Setup;
using Metrics;
using Metrics.Impl;
using UnityEngine;

namespace Architecture.Services.Impl {
    public class ResourcesMetricProvider : IMetricProvider {
        private const string PlayerMetricPath = "Metrics/PlayerMetric";
        private const string EnemyMetricFolderPath = "Metrics/Enemies/";
        private const string MetricSuffix = "Metric"; 

        public IPlayerMetric PlayerMetric => Resources.Load<PlayerMetric>(PlayerMetricPath);

        public IEnemyMetric EnemyMetric(EnemyId enemyId) {
            var path = SetupEnemyMetricPath(enemyId);
            return Resources.Load<EnemyMetric>(path);
        }

        private string SetupEnemyMetricPath(EnemyId enemyId) 
            => EnemyMetricFolderPath + enemyId.ToString() + MetricSuffix;
    }
}
