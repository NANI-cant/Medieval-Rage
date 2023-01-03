using System;
using Gameplay.Enemy.StateMachine;
using Gameplay.Fighting;
using Gameplay.Player;
using Gameplay.Teaming;
using Gameplay.Utils;
using UnityEngine;

namespace Gameplay.Enemy {
    [RequireComponent(typeof(Aggro))]
    [RequireComponent(typeof(AIMover))]
    [RequireComponent(typeof(AttackTargetPriority))]
    [RequireComponent(typeof(Health.Health))]
    [RequireComponent(typeof(AutoAttack))]
    [RequireComponent(typeof(EnemyAnimator))]
    [RequireComponent(typeof(Team))]
    [RequireComponent(typeof(DestroyObserver))]
    [RequireComponent(typeof(Rotator))]
    public class Enemy : MonoBehaviour {
        private EnemyStateMachine _stateMachine;
        private Aggro _aggro;
        private AIMover _mover;
        private AutoAttack _autoAttack;
        private EnemyAnimator _animator;
        private Health.Health _health;
        private bool _isMine;

        private void Awake() {
            _aggro = GetComponent<Aggro>();
            _mover = GetComponent<AIMover>();
            _autoAttack = GetComponent<AutoAttack>();
            _animator = GetComponent<EnemyAnimator>();
            _health = GetComponent<Health.Health>();
            _isMine = true;
            
            _stateMachine = new EnemyStateMachine(_autoAttack, _mover, _aggro, _animator);
        }

        public void Construct(bool isMine) => _isMine = isMine;

        private void Start() {
            if (_isMine) {
                _stateMachine.TranslateTo<CalmState>();        
            }
            else {
                _stateMachine.TranslateTo<NetworkAvatarState>();
            }
        }
        
        private void OnEnable() => _health.Died += OnDied;
        private void OnDisable() => _health.Died -= OnDied;
        public void Update() => _animator.Speed = _mover.DesiredSpeed / _mover.MaxSpeed;
        
        private void OnDied() => Destroy(gameObject);
    }
}