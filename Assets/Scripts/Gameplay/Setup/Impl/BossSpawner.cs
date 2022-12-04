using System;
using UnityEngine;

namespace Gameplay.Setup.Impl {
    public class BossSpawner : MonoBehaviour, IBossSpawner {
        [SerializeField] private EnemyId _bossId;

        private Health.Health _trackedHealth;

        public EnemyId BossId => _bossId;
        public Vector3 Position => transform.position;
        public Quaternion Rotation => transform.rotation;
        public bool IsSlayed => _trackedHealth == null;

        public event Action Slayed;

        public void Track(GameObject boss) {
            var health = boss.GetComponent<Health.Health>();
            health.Died += OnTrackedDied;
            _trackedHealth = health;
        }
        
        private void OnTrackedDied() {
            _trackedHealth = null;
            Slayed?.Invoke();
        }
    }
}