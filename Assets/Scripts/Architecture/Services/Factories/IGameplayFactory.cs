using System;
using Gameplay.Setup;
using UnityEngine;

namespace Architecture.Services.Factories {
    public interface IGameplayFactory {
        event Action<GameObject> PlayerCreated;
        event Action<GameObject, EnemyId> EnemyCreated;
        
        GameObject CreatePlayerCharacter(Vector3 position, Quaternion rotation);
        GameObject CreateEnemy(EnemyId enemyId, Vector3 position, Quaternion rotation);
    }
}
