using System;
using Architecture.Services;
using UnityEngine;

namespace Gameplay.Setup.Impl {
    public class PlayerSpawner : MonoBehaviour, IPlayerSpawner {
        private Health.Health _trackedHealth;
        private GameObject _player;
        private IResetUnitService _resetService;

        public Vector3 Position => transform.position;
        public Quaternion Rotation => transform.rotation;

        public void TrackPlayer(GameObject player, IResetUnitService resetService) {
            _resetService = resetService;
            _player = player;
            _trackedHealth = player.GetComponent<Health.Health>();
            _trackedHealth.Died += Respawn;
        }

        private void OnDestroy() {
            _trackedHealth.Died -= Respawn;
        }

        private void Respawn() {
            _player.SetActive(false);
            this.Invoke(() => {
                _player.transform.position = Position;
                _player.transform.rotation = Rotation;
                _resetService.ResetPlayer(_player);
                _player.SetActive(true);
            }, 5f);
        }
    }
}
