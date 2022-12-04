using System;
using Architecture.Services.General;
using Gameplay.Fighting;
using Gameplay.Teaming;
using Gameplay.Utils;
using UnityEngine;

namespace Gameplay.Enemy {
    [RequireComponent(typeof(AIMover))]
    [RequireComponent(typeof(Health.Health))]
    [RequireComponent(typeof(Team))]
    public class Aggro: MonoBehaviour {
        [SerializeField] private SphereTriggerObserver _trigger;

        public event Action CalmedDown;
        public event Action Aggrieved;

        private float _duration = 5f;
        private AIMover _mover;
        private Health.Health _health;
        private Health.Health _aggroTarget;
        private Timer _calmDownTimer;
        private ITimeProvider _timeProvider;
        private Team _team;

        public void Construct(float duration, float radius, ITimeProvider timeProvider) {
            _duration = duration;
            _timeProvider = timeProvider;
            _trigger.Radius = radius;
        }

        private void Awake() {
            _mover = GetComponent<AIMover>();
            _health = GetComponent<Health.Health>();
            _team = GetComponent<Team>();
        }

        private void OnEnable() {
            _health.HitTaken += ReactToHit;
            _trigger.Enter += ReactTriggerEnter;   
        }

        private void OnDisable() {
            if(_aggroTarget != null) _aggroTarget.Died -= CalmDown;
            _health.HitTaken -= ReactToHit;
            _trigger.Enter -= ReactTriggerEnter;   
        }

        private void Update() {
            _calmDownTimer?.Tick(_timeProvider.DeltaTime);
            
            if(_aggroTarget == null) return;
            _mover.MoveTo(_aggroTarget.transform.position);
        }

        public void TryAggro(Component potentialTarget) {
            if (_aggroTarget != null) return;
            if (!potentialTarget.TryGetComponent<Health.Health>(out var health)) return;
            if (potentialTarget.TryGetComponent<Team>(out var targetTeam) && _team.Id == targetTeam.Id) return;

            _aggroTarget = health;

            _aggroTarget.Died += CalmDown;
            _calmDownTimer = new Timer(_duration, CalmDown);
            Aggrieved?.Invoke();
        }

        public void TurnOn() {
            enabled = true;
            _trigger.Activate();
        }

        public void TurnOff() {
            enabled = false;
            _trigger.Deactivate();
        }

        private void ReactTriggerEnter(Collider other) => TryAggro(other);
        private void ReactToHit(TakeHitResult takeHitResult) => TryAggro(takeHitResult.DamageDealer);

        private void CalmDown() {
            _calmDownTimer = null;
            _aggroTarget.Died -= CalmDown;
            _aggroTarget = null;
            CalmedDown?.Invoke();
        }
    }
}