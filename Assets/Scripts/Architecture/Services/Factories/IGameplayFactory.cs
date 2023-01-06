using System;
using Gameplay.Setup;
using UnityEngine;

namespace Architecture.Services.Factories {
    public interface IGameplayFactory {
        event Action<GameObject> PlayerCreated;

        GameObject CreatePlayerCharacter(Vector3 position, Quaternion rotation);
        GameObject CreateEnemy(EnemyId enemyId, Vector3 position, Quaternion rotation);
    }
}
