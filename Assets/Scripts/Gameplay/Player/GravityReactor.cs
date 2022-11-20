using UnityEngine;

namespace Gameplay.Player {
    [RequireComponent(typeof(CharacterController))]
    public class GravityReactor : MonoBehaviour {
        [SerializeField] private float _gravityAcceleration = 9.8f;

        private CharacterController _controller;
        private float _fallingSpeed = 0f;

        private void Awake() {
            _controller = GetComponent<CharacterController>();
        }

        private void Update() {
            CalculateFallingSpeed();
            FallDueToGravity();
        }

        private void FallDueToGravity() {
            _controller.Move(Vector3.down * _fallingSpeed * Time.deltaTime);
        }

        private void CalculateFallingSpeed() {
            if (_controller.isGrounded) {
                _fallingSpeed = 0f;
            }
            else {
                _fallingSpeed += _gravityAcceleration * Time.deltaTime;
            }
        }
    }
}