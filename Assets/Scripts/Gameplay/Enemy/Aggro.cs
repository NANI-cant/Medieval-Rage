using System.Collections;
using Gameplay.Player;
using Gameplay.Utils;
using UnityEngine;

namespace Gameplay.Enemy {
    [RequireComponent(typeof(AIMover))]
    public class Aggro: MonoBehaviour {
        [SerializeField] private TriggerObserver _trigger;

        private float _duration = 5f;
        private AIMover _mover;
        private Transform _aggroTarget;
        private Coroutine _aggroStopping;

        private bool HasAggroTarget => _aggroTarget != null;

        public void Construct(float duration) {
            _duration = duration;
        } 

        private void Awake() {
            _mover = GetComponent<AIMover>();
        }

        private void OnEnable() => _trigger.Enter += OnTriggerEnter;
        private void OnDisable() => _trigger.Enter -= OnTriggerEnter;

        private void Update() {
            if(_aggroTarget == null) return;
            
            _mover.MoveTo(_aggroTarget.position);
        }

        private void OnTriggerEnter(Collider other) {
            if(HasAggroTarget) return;
            
            if (other.TryGetComponent<Character>(out var character)) {
                _aggroTarget = character.transform;
                StartCoroutine(StopAggro());
            }
        }

        private IEnumerator StopAggro() {
            yield return new WaitForSeconds(_duration);
            _aggroTarget = null;
            _mover.ReturnToSpawn();
        }
    }
}