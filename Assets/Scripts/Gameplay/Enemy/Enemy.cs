using System;
using Gameplay.Enemy.StateMachine;
using Gameplay.Fighting;
using UnityEngine;

namespace Gameplay.Enemy {
    [RequireComponent(typeof(Aggro))]
    [RequireComponent(typeof(AIMover))]
    [RequireComponent(typeof(AttackTargetPriority))]
    [RequireComponent(typeof(Health.Health))]
    [RequireComponent(typeof(AutoAttack))]
    public class Enemy : MonoBehaviour {
        private EnemyStateMachine _stateMachine;
        private Aggro _aggro;
        private AIMover _mover;
        private AutoAttack _autoAttack;
        
        public void Awake() {
            _aggro = GetComponent<Aggro>();
            _mover = GetComponent<AIMover>();
            _autoAttack = GetComponent<AutoAttack>();
            
            _stateMachine = new EnemyStateMachine(_autoAttack, _mover, _aggro);
        }

        public void Update() {
            _stateMachine.Update();
        }
    }
}