using UnityEngine;

namespace Gameplay.Player {
    [RequireComponent(typeof(CharacterController))]
    public class Mover : MonoBehaviour {
        private CharacterController _controller;
        private float _speed;

        public void Construct(float speed) {
            _speed = speed;
        }

        private void Awake() {
            _controller = GetComponent<CharacterController>();
        }

        public void MoveTo(Vector3 direction) {
            _controller.Move(direction * _speed * Time.deltaTime);
        }
    }
}