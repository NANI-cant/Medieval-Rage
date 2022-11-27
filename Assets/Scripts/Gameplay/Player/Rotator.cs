using Architecture.Services;
using UnityEngine;

namespace Gameplay.Player {
    public class Rotator : MonoBehaviour {
        private float _angularSpeed;
        private Transform _transform;
        private ITimeProvider _timeProvider;

        public void Construct(float angularSpeed, ITimeProvider timeProvider) {
            _angularSpeed = angularSpeed;
            _timeProvider = timeProvider;
        }
        
        public void ResetToDefault(float angularSpeed) {
            _angularSpeed = angularSpeed;
        }

        private void Awake() {
            _transform = transform;
        }

        public void Rotate(Vector3 direction) {
            direction.y = 0;
            var currentDirection = _transform.forward;
            
            var rotationDelta = Quaternion.FromToRotation(currentDirection,direction);
            var targetRotation = _transform.rotation * rotationDelta;
            var smoothRotation = Quaternion.RotateTowards(_transform.rotation, targetRotation, _angularSpeed * _timeProvider.DeltaTime);

            _transform.rotation = smoothRotation;
        }

        public void RotateTo(Vector3 point) {
            point.y = _transform.position.y;
            var direction = (point - transform.position).normalized;
            Rotate(direction);
        }
    }
}