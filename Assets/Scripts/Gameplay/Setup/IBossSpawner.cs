using System;
using UnityEngine;

namespace Gameplay.Setup {
    public interface IBossSpawner: ISpawnPoint {
        EnemyId BossId { get; }
        bool IsSlayed { get; }
        event Action Slayed;
        void Track(GameObject boss);
    }
}