using UnityEngine;

namespace Gameplay.Setup.Impl {
    public class TraderSpawnPoint : MonoBehaviour, ITraderSpawnPoint {
        public Vector3 Position => transform.position;
        public Quaternion Rotation => transform.rotation;
    }
}