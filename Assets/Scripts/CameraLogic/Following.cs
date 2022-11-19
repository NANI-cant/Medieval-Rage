using UnityEngine;

namespace CameraLogic {
    [RequireComponent(typeof(Camera))]
    public class Following : MonoBehaviour {
        private Transform _target;
        private Transform _transform;

        public void Follow(Transform target) {
            _target = target;
        }

        private void Awake() {
            _transform = transform;
        }

        private void Update()
            => _transform.position = new Vector3(_target.position.x, _transform.position.y, _target.position.z);
    }
}