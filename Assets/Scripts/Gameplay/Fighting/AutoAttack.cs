using System;
using Architecture.Services;
using Gameplay.Utils;
using UnityEngine;
// TODO добавить очередь в TriggerEnter, переделать на подобии Aggro
namespace Gameplay.Fighting {
    public class AutoAttack: MonoBehaviour {
        [SerializeField] private TriggerObserver _trigger;

        private float _coolDown;
        private AttackData _attackData;
        private AttackTarget _target;
        private Timer _cooldownTimer;
        private ITimeProvider _timeProvider;
        private bool _isReady = true;
        private bool _isOn = true;

        public event Action Swung;
        public event Action TargetCaptured;
        public event Action TargetLost;
        
        public AttackTarget Target => _target;

        public void Construct(float coolDown, AttackData attackData, ITimeProvider timeProvider) {
            _coolDown = coolDown;
            _attackData = attackData;
            _timeProvider = timeProvider;
        }

        private void Update() {
            _cooldownTimer?.Tick(_timeProvider.DeltaTime);
            if(!_isOn) return;
            
            if(_isReady && _target != null) Attack(_target.Damageable);
        }

        private void OnEnable() {
            _trigger.Enter += OnTriggerEnter;
            _trigger.Exit += OnTriggerExit;
        }

        private void OnDisable() {
            _trigger.Enter -= OnTriggerEnter;
            _trigger.Exit -= OnTriggerExit;
        }

        public void Interrupt() {
            
        }

        private void Attack(IDamageable damageable){
            damageable.TakeHit(_attackData);

            _isReady = false;
            _cooldownTimer = new Timer(_coolDown, () => _isReady = true);
            Swung?.Invoke();
        }

        public void TurnOn() => _isOn = true;
        public void TurnOff() => _isOn = false;

        private void OnTriggerEnter(Collider other) {
            if(other.gameObject == gameObject) return;
            if (!other.TryGetComponent<IDamageable>(out var damageable)) return;
            
            int priority = other.TryGetComponent<AttackTargetPriority>(out var targetPriority)
                ? targetPriority.Priority
                : int.MaxValue;

            AttackTarget potentialTarget = new AttackTarget(damageable, priority, other.transform);
            
            if (_target == null) {
                _target = potentialTarget;
                TargetCaptured?.Invoke();
                return;
            }
            
            if(_target.Priority <= potentialTarget.Priority) return;

            _target = potentialTarget;
        }

        private void OnTriggerExit(Collider other) {
            if(other.gameObject == gameObject) return;
            if (!other.TryGetComponent<IDamageable>(out var damageable)) return;
            if(_target == null) return;
            if(_target.Damageable != damageable) return;

            _target = null;
            TargetLost?.Invoke();
        }
    }
}