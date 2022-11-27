using System;
using UnityEngine;

namespace Gameplay.Utils {
    [RequireComponent(typeof(SphereCollider))]
    public class SphereTriggerObserver: MonoBehaviour, ITriggerObserver {
        [SerializeField] private SphereCollider _collider;

        public event Action<Collider> Enter;
        public event Action<Collider> Exit;

        public float Radius {
            get => _collider.radius;
            set => _collider.radius = value;
        }

        private void OnTriggerEnter(Collider other) => Enter?.Invoke(other);
        private void OnTriggerExit(Collider other) => Exit?.Invoke(other);

        public void Activate() => _collider.enabled = true;
        public void Deactivate() => _collider.enabled = false;

#if UNITY_EDITOR
        private void OnValidate() {
            _collider = GetComponent<SphereCollider>();
        }
#endif
    }
}