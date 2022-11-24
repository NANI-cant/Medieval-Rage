using System;
using Architecture.Services;
using Gameplay.Player;
using Gameplay.Utils;
using UnityEngine;

namespace Gameplay.Enemy {
    [RequireComponent(typeof(AIMover))]
    public class Aggro: MonoBehaviour {
        [SerializeField] private TriggerObserver _trigger;

        public event Action CalmedDown;
        public event Action Aggrieved;

        private float _duration = 5f;
        private AIMover _mover;
        private Transform _aggroTarget;
        private bool _isOn = true;
        private bool _canBeAggro = true;
        private Timer _calmDownTimer;
        private ITimeProvider _timeProvider;

        private bool HasAggroTarget => _aggroTarget != null;

        public void Construct(float duration, ITimeProvider timeProvider) {
            _duration = duration;
            _timeProvider = timeProvider;
        } 

        private void Awake() => _mover = GetComponent<AIMover>();
        private void OnEnable() => _trigger.Enter += OnTriggerEnter;
        private void OnDisable() => _trigger.Enter -= OnTriggerEnter;

        private void Update() {
            if(!_canBeAggro) return;
            _calmDownTimer?.Tick(_timeProvider.DeltaTime);
            
            if(_aggroTarget == null) return;
            if(!_isOn) return;
            _mover.MoveTo(_aggroTarget.position);
        }

        public void CanBeAggro() {
            _canBeAggro = true;
            if(_aggroTarget == null) return;
            
            Aggrieved?.Invoke();
        }
        
        public void TurnOn() => _isOn = true;

        public void TurnOff() {
            _mover.Stop();
            _isOn = false;  
        }

        private void OnTriggerEnter(Collider other) {
            if(HasAggroTarget) return;
            if (!other.TryGetComponent<Character>(out var character)) return;
            
            _aggroTarget = character.transform;
            if(_canBeAggro) Aggrieved?.Invoke();
            _calmDownTimer = new Timer(_duration, () => {
                _aggroTarget = null;
                CalmedDown?.Invoke();
            });
        }
    }
}