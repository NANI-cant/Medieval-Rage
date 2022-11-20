using System;
using UnityEngine;
using UnityEngine.AI;

namespace Gameplay.Enemy {
    [RequireComponent(typeof(NavMeshAgent))]
    public class AIMover : MonoBehaviour {
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
            _agent.destination = destination;
        }

        public void ReturnToSpawn() {
            MoveTo(_startPosition);
        }
    }
}