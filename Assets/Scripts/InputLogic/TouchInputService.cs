using System;
using Architecture.Abstraction;
using Architecture.Services;
using UnityEngine;

namespace InputLogic {
    public class TouchInputService : IInputService, IUpdatable {
        public event Action<Vector3> TapDetected;

        private readonly Camera _mainCamera;
        private bool _enabled;

        public TouchInputService(Camera mainCamera) {
            _mainCamera = mainCamera;
        }

        public void Enable() => _enabled = true;
        public void Disable() => _enabled = false;

        public void Update() {
            if (Input.GetMouseButtonDown(0)) {
                Vector3 globalPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
                TapDetected?.Invoke(globalPosition);
            }
        }
    }
}