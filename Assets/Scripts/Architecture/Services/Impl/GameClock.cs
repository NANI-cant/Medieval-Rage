using System;
using Architecture.Services.General;
using Zenject;

namespace Architecture.Services.Impl {
    public class GameClock: IGameClock, ITickable {
        private readonly ITimeProvider _timeProvider;
        private bool _isStopped = true;

        public GameClock(ITimeProvider timeProvider) {
            _timeProvider = timeProvider;
        }

        public event Action EnemiesShouldSpawn;
        public event Action Ticked;

        public float Time { get; private set; } = 0;

        public void Start() => _isStopped = false;
        public void Stop() => _isStopped = true;

        public void Tick() {
            if(_isStopped) return;
            Time += _timeProvider.DeltaTime;
            if (Time % 10 <= _timeProvider.DeltaTime) EnemiesShouldSpawn?.Invoke();
            Ticked?.Invoke();
        }
    }
}