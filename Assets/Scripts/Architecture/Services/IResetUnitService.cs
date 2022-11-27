using Gameplay.Setup;
using UnityEngine;

namespace Architecture.Services {
    public interface IResetUnitService {
        void ResetPlayer(GameObject player);
        void ResetEnemy(GameObject enemy, EnemyId enemyId);
    }
}