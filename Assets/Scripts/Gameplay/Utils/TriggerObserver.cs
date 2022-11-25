using System;
using UnityEngine;

namespace Gameplay.Utils {
    [RequireComponent(typeof(Collider))]
    public class TriggerObserver: MonoBehaviour {
        [SerializeField] private Collider _collider;
        
        public event Action<Collider> Enter;
        public event Action<Collider> Exit;

        private void OnTriggerEnter(Collider other) => 
            Enter?.Invoke(other);

        private void OnTriggerExit(Collider other) => 
            Exit?.Invoke(other);

        public void Activate() {
            gameObject.SetActive(true);
            _collider.enabled = true;
        }

        public void Deactivate() {
            gameObject.SetActive(false);
            _collider.enabled = false;
        }

#if UNITY_EDITOR
        private void OnValidate() {
            _collider = GetComponent<Collider>();
        }
#endif
    }
}