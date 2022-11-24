using System;
using Gameplay.Fighting;
using Gameplay.Player.StateMachine;
using UnityEngine;

namespace Gameplay.Player {
    [RequireComponent(typeof(Mover))]
    [RequireComponent(typeof(Rotator))]
    [RequireComponent(typeof(GravityReactor))]
    [RequireComponent(typeof(Health.Health))]
    [RequireComponent(typeof(CharacterAnimator))]
    [RequireComponent(typeof(AutoAttack))]
    public class Character : MonoBehaviour {
        private CharacterStateMachine _stateMachine;
        private Mover _mover;
        private CharacterAnimator _animator;
        private Rotator _rotator;
        private AutoAttack _autoAttack;

        private void Awake() {
            _mover = GetComponent<Mover>();
            _animator = GetComponent<CharacterAnimator>();
            _rotator = GetComponent<Rotator>();
            _autoAttack = GetComponent<AutoAttack>();
            
            _stateMachine = new CharacterStateMachine(_animator, _autoAttack, _mover, _rotator);
        }

        private void Update() {
            _stateMachine.Update();
        }

        public void Move(Vector3 direction) {
            _animator.Speed = direction.magnitude;

            _mover.Move(direction);
            _rotator.Rotate(direction);
        }
    }
}