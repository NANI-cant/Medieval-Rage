using Metrics;
using UnityEngine;
using UnityEngine.AI;

namespace Gameplay.Player {
    [RequireComponent(typeof(NavMeshAgent))]
    public class Mover : MonoBehaviour {
        [SerializeField] private PlayerMetric _metric;

        private Transform _transform;
        private NavMeshAgent _navMeshAgent;

        private void Awake() {
            _transform = GetComponent<Transform>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Start() {
            _navMeshAgent.speed = _metric.Speed;
            _navMeshAgent.acceleration = float.MaxValue;
            _navMeshAgent.angularSpeed = float.MaxValue;
        }

        public void MoveTo(Vector3 destination) {
            _navMeshAgent.destination = destination;
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected() {
            if (_navMeshAgent == null) return;

            Gizmos.color = Color.green;
            for (int i = 0; i < _navMeshAgent.path.corners.Length - 1; i++) {
                Vector3 current = _navMeshAgent.path.corners[i];
                Vector3 next = _navMeshAgent.path.corners[i + 1];

                Gizmos.DrawLine(current, next);
            }
        }
#endif
    }
}