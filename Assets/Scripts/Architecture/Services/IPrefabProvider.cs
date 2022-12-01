using Gameplay.Setup;
using UnityEngine;

namespace Architecture.Services {
    public interface IPrefabProvider {
        string PlayerPath { get; }
        GameObject PlayerCharacter { get; }

        string EnemyPath(EnemyId enemyId);
        GameObject Enemy(EnemyId enemyId);
    }
}
