using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Setup.Impl {
    public class EnemySpawner: MonoBehaviour, IEnemySpawner {
        [SerializeField] private int _iD;
        [SerializeField] private EnemyPack[] _packs;
        [SerializeField] private float _spawningRadius;
        
        private readonly List<Health.Health> _trackedHealths = new ();

        public int ID => _iD;
        public Vector3 Position => transform.position;
        public float SpawningRadius => _spawningRadius;
        public Quaternion Rotation => transform.rotation;
        public EnemyPack[] Packs => _packs;
        public bool IsSlayed => _trackedHealths.Count == 0;

        public void Track(GameObject[] enemies) {
            foreach (var enemy in enemies) {
                var enemyHealth = enemy.GetComponent<Health.Health>();
                enemyHealth.Died += OnTrackedDied;
                _trackedHealths.Add(enemyHealth);
            }
        }

        private void OnTrackedDied() {
            for (int i = 0; i < _trackedHealths.Count; i++) {
                var currentHealth = _trackedHealths[i];
                if (currentHealth.CurrentHealth == 0) {
                    _trackedHealths.Remove(currentHealth);
                    break;
                }
            }
        }
    }
}

