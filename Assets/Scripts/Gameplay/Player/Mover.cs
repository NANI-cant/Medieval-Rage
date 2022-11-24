using System;
using UnityEngine;

namespace Gameplay.Player {
    [RequireComponent(typeof(CharacterController))]
    public class Mover : MonoBehaviour {
        public event Action Stopped;
        public event Action Started;
        
        private CharacterController _controller;
        private float _maxSpeed;
        private Vector3 _lastPosition;
        private float _lastTranslation;

        public void Construct(float maxSpeed) {
            _maxSpeed = maxSpeed;
        }

        private void Awake() {
            _controller = GetComponent<CharacterController>();
        }

        public void Move(Vector3 direction) {
            _controller.Move(direction * _maxSpeed * Time.deltaTime);
            
            Vector3 currentPosition = transform.position;
            float currentTranslation = Vector3.Distance(currentPosition, _lastPosition);
            
            if (currentTranslation > 0 && _lastTranslation == 0) Started?.Invoke();
            if (currentTranslation == 0 && _lastTranslation > 0) Stopped?.Invoke();

            _lastPosition = currentPosition;
            _lastTranslation = currentTranslation;
        }
    }
}