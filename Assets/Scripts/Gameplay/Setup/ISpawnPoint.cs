using UnityEngine;

namespace Gameplay.Setup {
    public interface ISpawnPoint {
        public Vector3 Position { get; }
        public Quaternion Rotation { get; }
    }
}