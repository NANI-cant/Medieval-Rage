using Architecture.Services;
using Architecture.Services.Gameplay;
using UnityEngine;

namespace Gameplay.Player {
    [RequireComponent(typeof(Character))]
    public class PlayerInputBrain : MonoBehaviour {
        private IInputService _inputService;
        private Character _character;

        public void Construct(IInputService inputService) {
            _inputService = inputService;
        }

        private void Awake() => _character = GetComponent<Character>();
        public void Update() => _character.Move(_inputService.Direction);
    }
}