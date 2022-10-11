using Architecture.Services;
using UnityEngine;
using Zenject;

namespace Gameplay.Player {
    [RequireComponent(typeof(Mover))]
    public class PlayerInputBrain : MonoBehaviour {
        private IInputService _inputService;
        private Mover _mover;

        [Inject]
        public void Construct(IInputService inputService) {
            _inputService = inputService;
        }

        private void Awake() {
            _mover = GetComponent<Mover>();
        }

        private void OnEnable() => _inputService.TapDetected += OnTapDetected;
        private void OnDisable() => _inputService.TapDetected -= OnTapDetected;

        private void OnTapDetected(Vector3 position) {
            _mover.MoveTo(position);
        }
    }
}