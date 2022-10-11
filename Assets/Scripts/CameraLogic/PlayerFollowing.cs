using Gameplay.Player;
using UnityEngine;
using Zenject;

namespace CameraLogic {
    [RequireComponent(typeof(Camera))]
    public class PlayerFollowing : MonoBehaviour {
        private PlayerInputBrain _targetPlayer;
        private Transform _transform;

        [Inject]
        public void Construct(PlayerInputBrain playerBrain) {
            _targetPlayer = playerBrain;
        }

        private void Awake() {
            _transform = transform;
        }

        private void Update() {
            _transform.position = new Vector3(_targetPlayer.transform.position.x, _transform.position.y, _targetPlayer.transform.position.z);
        }
    }
}