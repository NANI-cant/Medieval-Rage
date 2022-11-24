using System;
using UnityEngine;
using UnityEngine.AI;

namespace Gameplay.Enemy {
    [RequireComponent(typeof(NavMeshAgent))]
    public class AIMover : MonoBehaviour {
        public event Action ReturnedToSpawn;
        
        private NavMeshAgent _agent;
        private Vector3 _startPosition;

        public void Construct(float speed) {
            _agent.speed = speed;
        }

        private void Awake() {
            _agent = GetComponent<NavMeshAgent>();
            _startPosition = transform.position;
        }

        public void MoveTo(Vector3 destination) {
            _agent.SetDestination(destination);
        }

        public void ReturnToSpawn() {
            MoveTo(_startPosition);
            this.Invoke(() => ReturnedToSpawn?.Invoke(), _agent.remainingDistance / _agent.speed);
        }

        public void Stop() {
            _agent.SetDestination(transform.position);
        }
    }
}