using UnityEngine;

namespace Gameplay.Setup.Impl {
    public class TraderSpawner : MonoBehaviour, ITraderSpawner {
        public Vector3 Position => transform.position;
        public Quaternion Rotation => transform.rotation;
    }
}