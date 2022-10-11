using System;
using Architecture.Abstraction;
using Architecture.Services;
using UnityEngine;

namespace InputLogic {
    public class TouchInputService : IInputService, IUpdatable {
        public event Action<Vector3> TapDetected;

        private readonly Camera _mainCamera;
        private readonly LayerMask _touchableLayers;

        private bool _enabled;

        public TouchInputService(Camera mainCamera, LayerMask touchableLayers) {
            _mainCamera = mainCamera;
            _touchableLayers = touchableLayers;
        }

        public void Enable() => _enabled = true;
        public void Disable() => _enabled = false;

        public void Update() {
            if (Input.GetMouseButtonDown(0)) {
                Ray ray = _mainCamera.ViewportPointToRay(_mainCamera.ScreenToViewportPoint(Input.mousePosition));
                if (Physics.Raycast(ray, out RaycastHit hitResult, float.MaxValue, _touchableLayers)) {
                    TapDetected?.Invoke(hitResult.point);
                }
            }
        }
    }
}