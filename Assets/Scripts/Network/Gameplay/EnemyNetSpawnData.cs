using Gameplay.Setup;
using UnityEngine;

namespace Architecture.Services.Network.Impl {
    public readonly struct EnemyNetSpawnData {
        public readonly int ViewID;
        public readonly EnemyId EnemyId;
        public readonly Vector3 Position;
        public readonly Quaternion Rotation;
        public readonly int SpawnerId;

        public EnemyNetSpawnData(int viewID, EnemyId enemyId, Vector3 position, Quaternion rotation, int spawnerId) {
            ViewID = viewID;
            EnemyId = enemyId;
            Position = position;
            Rotation = rotation;
            SpawnerId = spawnerId;
        }
    }
}