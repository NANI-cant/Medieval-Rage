using UnityEngine;

namespace Gameplay.Setup {
    public interface IEnemySpawner: ISpawnPoint {
        float SpawningRadius { get; }
        EnemyPack[] Packs { get; }
        bool IsSlayed { get; }

        void Track(GameObject[] enemies);
    }
}