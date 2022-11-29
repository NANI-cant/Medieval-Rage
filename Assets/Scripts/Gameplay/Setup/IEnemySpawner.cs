﻿using UnityEngine;

namespace Gameplay.Setup {
    public interface IEnemySpawner: ISpawnPoint {
        EnemyPack[] Packs { get; }
        bool IsSlayed { get; }

        void Track(GameObject[] enemies);
    }
}