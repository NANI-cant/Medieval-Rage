using UnityEngine;

namespace Gameplay.Teaming {
    public class Team: MonoBehaviour {
        public int Id { get; set; }

        public void Construct(int teamId) {
            Id = teamId;
        }
    }
}