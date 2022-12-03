using Architecture.Services;
using Architecture.Services.Factories;
using UnityEngine;

namespace Gameplay.Setup.Impl {
    public class PlayerSpawner : MonoBehaviour, IPlayerSpawner {
        private Health.Health _trackedHealth;
        private GameObject _player;
        private IGameplayFactory _factory;

        public Vector3 Position => transform.position;
        public Quaternion Rotation => transform.rotation;

        public void TrackPlayer(GameObject player) {
            _player = player;
            _trackedHealth = player.GetComponent<Health.Health>();
            _trackedHealth.Died += Respawn;
        }

        private void OnDestroy() {
            if(_trackedHealth == null) return;
            _trackedHealth.Died -= Respawn;
        }

        private void Respawn() {
            
        }
    }
}
