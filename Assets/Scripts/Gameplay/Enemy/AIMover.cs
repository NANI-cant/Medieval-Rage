using System;
using UnityEngine;
using UnityEngine.AI;

namespace Gameplay.Enemy {
    [RequireComponent(typeof(NavMeshAgent))]
    public class AIMover : MonoBehaviour {
        public event Action ReturnedToSpawn;
        
        private NavMeshAgent _agent;
        private Vector3 _startPosition;
        public float MaxSpeed => _agent.speed;
        public float DesiredSpeed => _agent.desiredVelocity.magnitude;

        public void Construct(float speed, float angularSpeed, int agentPriority) {
            _agent.speed = speed;
            _agent.angularSpeed = angularSpeed;
            _agent.avoidancePriority = agentPriority;
        }

        private void Awake() {
            _startPosition = transform.position;
            _agent = GetComponent<NavMeshAgent>();  
        } 

        public void MoveTo(Vector3 destination) => _agent.SetDestination(destination);
        public void Stop() => _agent.SetDestination(transform.position);

        public void ReturnToSpawn() {
            MoveTo(_startPosition);
            this.Invoke(() => ReturnedToSpawn?.Invoke(), _agent.remainingDistance * 3f/ _agent.speed);
        }
    }
}