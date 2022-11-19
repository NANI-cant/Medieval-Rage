using UnityEngine;

namespace Gameplay.Player {
    [RequireComponent(typeof(Mover))]
    public class Character : MonoBehaviour {
        private Mover _mover;

        private void Awake() {
            _mover = GetComponent<Mover>();
        }

        public void Move(Vector3 direction) {
            _mover.MoveTo(direction);
        }
    }
}