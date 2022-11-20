using Gameplay.Setup;
using UnityEngine;

namespace Architecture.Services {
    public interface IGameplayFactory {
        GameObject CreatePlayerCharacter(Vector3 position, Quaternion rotation);
        GameObject CreateEnemy(EnemyId enemyId, Vector3 position, Quaternion rotation);
    }
}
