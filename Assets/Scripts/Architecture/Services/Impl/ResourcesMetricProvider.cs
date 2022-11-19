using Metrics;
using Metrics.Impl;
using UnityEngine;

namespace Architecture.Services.Impl {
    public class ResourcesMetricProvider : IMetricProvider {
        private const string PlayerMetricPath = "Metrics/PlayerMetric";

        public IPlayerMetric PlayerMetric => Resources.Load<PlayerMetric>(PlayerMetricPath);
    }
}
