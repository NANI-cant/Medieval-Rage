using UnityEngine;

namespace CameraLogic {
    [RequireComponent(typeof(Camera))]
    public class Following : MonoBehaviour {
        [SerializeField] private float _angle = 30f;
        [SerializeField] private float _distance = 20f;
        private Transform _target;
        private Transform _transform;

        public void Follow(Transform target) {
            _target = target;
        }

        private void Awake() {
            _transform = transform;
        }

        private void Update() {
            if(_target == null) return;
            
            float angleInRad = Mathf.Deg2Rad * _angle;
            Vector3 offset = new Vector3(0, _distance * Mathf.Cos(angleInRad), _distance * Mathf.Sin(angleInRad) * -1);
            Vector3 global = _target.position + offset;
            
            _transform.position = global;
            _transform.forward = (_target.position - _transform.position).normalized;
        }
    }
}