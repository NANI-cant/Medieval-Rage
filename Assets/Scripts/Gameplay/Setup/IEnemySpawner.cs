using UnityEngine;

namespace Gameplay.Setup {
    public interface IEnemySpawner: ISpawnPoint {
        int ID { get; }
        float SpawningRadius { get; }
        EnemyPack[] Packs { get; }
        bool IsSlayed { get; }

        void Track(params GameObject[] enemies);
    }
}