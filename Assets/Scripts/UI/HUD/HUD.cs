using Architecture.Services;
using UnityEngine;

namespace UI.HUD {
    public class HUD: MonoBehaviour {
        [SerializeField] private GameClockView _gameClockView;
        
        public void Construct(IGameClock gameClock) {
            _gameClockView.Construct(gameClock);    
        }
    }
}