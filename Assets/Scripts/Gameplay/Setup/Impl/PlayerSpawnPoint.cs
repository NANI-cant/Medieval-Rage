using UnityEngine;

namespace Gameplay.Setup.Impl {
    public class PlayerSpawnPoint : MonoBehaviour, IPlayerSpawnPoint {
        public Vector3 Position => transform.position;
        public Quaternion Rotation => transform.rotation;
    }
}
