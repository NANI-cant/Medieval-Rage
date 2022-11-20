using Gameplay.Setup;
using UnityEngine;

namespace Architecture.Services {
    public interface IPrefabProvider {
        GameObject PlayerCharacter { get; }

        GameObject Enemy(EnemyId enemyId);
    }
}
