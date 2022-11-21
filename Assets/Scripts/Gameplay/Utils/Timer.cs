using System;

namespace Gameplay.Utils {
    public class Timer {
        private readonly Action _timesUpAction;
        private float _remindedTime;
        private bool _isAlreadyStop;
		
        public Timer(float time, Action timesUpAction) {
            _remindedTime = time;
            _timesUpAction = timesUpAction;
            _isAlreadyStop = false;
        }
		
        public void Tick(float deltaTime) {
            if(_isAlreadyStop) return;
			
            _remindedTime -= deltaTime;
            if (_remindedTime > 0) return;
			
            _timesUpAction?.Invoke();
            _isAlreadyStop = true;
        }
    }
}