using System;
using System.Collections.Generic;
using System.Linq;
using Architecture.Services;
using Gameplay.Player;
using Gameplay.Utils;
using UnityEngine;

namespace Gameplay.Fighting {
    [RequireComponent(typeof(Rotator))]
    public class AutoAttack: MonoBehaviour {
        [SerializeField] private SphereTriggerObserver _trigger;
        
        private float _coolDown;
        private List<AttackTarget> _targetsQueue = new ();
        private Rotator _rotator;
        private AttackData _attackData;
        private Timer _cooldownTimer;
        private ITimeProvider _timeProvider;
        private bool _isReady = true;
        private bool _isOn = true;

        public event Action Swung;
        public event Action TargetCaptured;
        public event Action TargetLost;

        public AttackTarget Target => _targetsQueue.Count > 0 ? _targetsQueue[0] : null;

        public void Construct(float coolDown, float radius, AttackData attackData, ITimeProvider timeProvider) {
            _coolDown = coolDown;
            _attackData = attackData;
            _timeProvider = timeProvider;
            _trigger.Radius = radius;
        }
        
        public void ResetToDefault(float coolDown, float radius, AttackData attackData) {
            _coolDown = coolDown;
            _attackData = attackData;
            _trigger.Radius = radius;
        }

        private void Awake() => _rotator = GetComponent<Rotator>();

        private void Update() {
            _cooldownTimer?.Tick(_timeProvider.DeltaTime);
            if(!_isOn) return;
            
            if(Target == null) return;
            _rotator.RotateTo(Target.Transform.position);
            
            if(!_isReady) return;
            Attack(Target.Damageable);
        }

        private void OnEnable() {
            _trigger.Enter += ReactTriggerEnter;
            _trigger.Exit += ReactTriggerExit;
        }

        private void OnDisable() {
            _trigger.Enter -= ReactTriggerEnter;
            _trigger.Exit -= ReactTriggerExit;
        }

        public void Interrupt() {
            
        }

        private void Attack(IDamageable damageable){
            damageable.TakeHit(_attackData, this);

            _isReady = false;
            _cooldownTimer = new Timer(_coolDown, () => _isReady = true);
            Swung?.Invoke();
        }

        public void TurnOn() => _isOn = true;
        public void TurnOff() => _isOn = false;

        private void ReactTriggerEnter(Collider other) {
            if(other.gameObject == gameObject) return;
            if (!TrySetupTarget(other, out AttackTarget potentialTarget)) return;
            
            _targetsQueue.Add(potentialTarget);
            _targetsQueue = _targetsQueue.OrderBy((target) => target.Priority).ToList();
            if(_targetsQueue.Count == 1) TargetCaptured?.Invoke();
        }

        private void ReactTriggerExit(Collider other) {
            if(other.gameObject == gameObject) return;
            if (!TrySetupTarget(other, out AttackTarget potentialTarget)) return;
            
            _targetsQueue.Remove(potentialTarget);
            if(_targetsQueue.Count == 0) TargetLost?.Invoke();
        }

        private static bool TrySetupTarget(Collider other, out AttackTarget potentialTarget) {
            potentialTarget = new AttackTarget(null, 0, null);
            if (!other.TryGetComponent<IDamageable>(out var damageable)) return false;
            int priority = other.TryGetComponent<AttackTargetPriority>(out var targetPriority)
                ? targetPriority.Priority
                : int.MaxValue;
            potentialTarget = new AttackTarget(damageable, priority, other.transform);
            return true;
        }
    }
}