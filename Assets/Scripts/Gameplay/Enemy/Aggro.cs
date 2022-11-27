using System;
using Architecture.Services;
using Gameplay.Player;
using Gameplay.Utils;
using UnityEngine;

namespace Gameplay.Enemy {
    [RequireComponent(typeof(AIMover))]
    public class Aggro: MonoBehaviour {
        [SerializeField] private SphereTriggerObserver _trigger;

        public event Action CalmedDown;
        public event Action Aggrieved;

        private float _duration = 5f;
        private AIMover _mover;
        private Transform _aggroTarget;
        private Timer _calmDownTimer;
        private ITimeProvider _timeProvider;

        public void Construct(float duration, float radius, ITimeProvider timeProvider) {
            _duration = duration;
            _timeProvider = timeProvider;
            _trigger.Radius = radius;
        } 

        private void Awake() => _mover = GetComponent<AIMover>();
        private void OnEnable() => _trigger.Enter += ReactTriggerEnter;
        private void OnDisable() => _trigger.Enter -= ReactTriggerEnter;

        private void Update() {
            _calmDownTimer?.Tick(_timeProvider.DeltaTime);
            
            if(_aggroTarget == null) return;
            _mover.MoveTo(_aggroTarget.position);
        }

        public void TurnOn() {
            enabled = true;
            _trigger.Activate();
        }

        public void TurnOff() {
            enabled = false;
            _trigger.Deactivate();
        }

        private void ReactTriggerEnter(Collider other) {
            if (_aggroTarget != null) return;
            if (!other.TryGetComponent<Character>(out var character)) return;
            
            _aggroTarget = character.transform;
            
            Aggrieved?.Invoke();
            _calmDownTimer = new Timer(_duration, () => {
                _aggroTarget = null;
                CalmedDown?.Invoke();
            });
        }
    }
}