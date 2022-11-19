using Metrics;

namespace Architecture.Services {
    public interface IMetricProvider {
        IPlayerMetric PlayerMetric { get; }
    }
}
