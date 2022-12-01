using Architecture.Services;
using Photon.Pun;
using UnityEngine;

namespace Gameplay.Player {
    [RequireComponent(typeof(Character))]
    public class PlayerInputBrain : MonoBehaviour {
        private IInputService _inputService;
        private Character _character;

        public void Construct(IInputService inputService) {
            _inputService = inputService;
        }

        private void Awake() {
            if (!GetComponent<PhotonView>().IsMine) {
                Destroy(this);
                return;
            }
            _character = GetComponent<Character>();
        }

        public void Update() {
            _character.Move(_inputService.Direction);
        }
    }
}