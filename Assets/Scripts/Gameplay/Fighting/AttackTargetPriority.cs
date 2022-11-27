using UnityEngine;

namespace Gameplay.Fighting {
    public class AttackTargetPriority: MonoBehaviour {
        public int Priority { get; private set; }

        public void Construct(int priority) {
            Priority = priority;
        }
        
        public void ResetToDefault(int priority) {
            Priority = priority;
        }
    }
}