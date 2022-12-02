using Gameplay.Setup;
using UnityEngine;

namespace Architecture.Services {
    public interface IPrefabProvider {
        GameObject Player { get; }
        
        GameObject Enemy(EnemyId enemyId);
    }
}
