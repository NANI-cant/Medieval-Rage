using Architecture.Services;
using UnityEngine;

namespace Gameplay.Player {
    public class Rotator : MonoBehaviour {
        private float _angularSpeed;
        private Transform _trasnform;
        private ITimeProvider _timeProvider;

        public void Construct(float angularSpeed, ITimeProvider timeProvider) {
            _angularSpeed = angularSpeed;
            _timeProvider = timeProvider;
        }

        private void Awake() {
            _trasnform = transform;
        }

        public void Rotate(Vector3 direction) {
            direction.y = 0;
            var currentDirection = _trasnform.forward;
            
            var rotationDelta = Quaternion.FromToRotation(currentDirection,direction);
            var targetRotation = _trasnform.rotation * rotationDelta;
            var smoothRotation = Quaternion.RotateTowards(_trasnform.rotation, targetRotation, _angularSpeed * _timeProvider.DeltaTime);

            _trasnform.rotation = smoothRotation;
        }

        public void RotateTo(Vector3 point) {
            point.y = _trasnform.position.y;
            var direction = (point - transform.position).normalized;
            Rotate(direction);
        }
    }
}