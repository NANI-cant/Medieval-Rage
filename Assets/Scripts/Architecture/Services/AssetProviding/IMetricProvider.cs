using Gameplay.Setup;
using Metrics;

namespace Architecture.Services.AssetProviding {
    public interface IMetricProvider {
        IPlayerMetric PlayerMetric { get; }
        
        IEnemyMetric EnemyMetric(EnemyId enemyId);
    }
}
