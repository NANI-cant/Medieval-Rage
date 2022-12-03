using Architecture.Services;
using Architecture.Services.Gameplay;
using TMPro;
using UnityEngine;

namespace UI.HUD {
    public class GameClockView: MonoBehaviour {
        [SerializeField] private TextMeshProUGUI _uGui;
        
        private IGameClock _gameClock;

        public void Construct(IGameClock gameClock) {
            _gameClock = gameClock;
            _gameClock.Ticked += UpdateText;
        }

        private void Start() => UpdateText();
        private void OnDestroy() => _gameClock.Ticked -= UpdateText;

        private void UpdateText() {
            int roundedTime = (int) _gameClock.Time;
            int minutes = roundedTime / 60;
            int seconds = roundedTime % 60;
            _uGui.text = $"{minutes}:{seconds:D2}";
        }

#if UNITY_EDITOR
        private void OnValidate() {
            if(_uGui != null) return;
            _uGui = GetComponent<TextMeshProUGUI>();
        }
#endif
    }
}