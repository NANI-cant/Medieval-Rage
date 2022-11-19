using Metrics.Impl;
using UnityEngine;

namespace Gameplay.Player {
    [RequireComponent(typeof(CharacterController))]
    public class Mover : MonoBehaviour {
        [SerializeField] private PlayerMetric _metric;

        private CharacterController _controller;

        private void Awake() {
            _controller = GetComponent<CharacterController>();
        }

        public void MoveTo(Vector3 direction) {
            _controller.Move(direction * _metric.Speed * Time.deltaTime);
        }
    }
}