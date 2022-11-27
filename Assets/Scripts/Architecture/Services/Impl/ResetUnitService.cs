using Gameplay.Fighting;
using Gameplay.Health;
using Gameplay.Player;
using Gameplay.Setup;
using UnityEngine;

namespace Architecture.Services.Impl {
    public class ResetUnitService: IResetUnitService {
        private readonly IMetricProvider _metricProvider;

        public ResetUnitService(
            IMetricProvider metricProvider
        ) {
            _metricProvider = metricProvider;
        }
        
        public void ResetPlayer(GameObject player) {
            var playerMetric = _metricProvider.PlayerMetric;
            
            player.GetComponent<Mover>().ResetToDefault(playerMetric.Speed);
            player.GetComponent<Rotator>().ResetToDefault(playerMetric.AngularSpeed);
            player.GetComponent<AutoAttack>().ResetToDefault(playerMetric.CoolDown, playerMetric.AttackRadius, playerMetric.AttackData);
            player.GetComponent<CharacterAnimator>().ResetToDefault(playerMetric.AttackSpeed);
            player.GetComponent<AttackTargetPriority>().ResetToDefault(playerMetric.AttackTargetPriority);
            player.GetComponent<Health>().ResetToDefault(playerMetric.MaxHealth);
        }

        public void ResetEnemy(GameObject enemy, EnemyId enemyId) {
            var enemyMetric = _metricProvider.EnemyMetric;
        }
    }
}