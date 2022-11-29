using System;

namespace Architecture.Services {
    public interface IGameClock {
        event Action EnemiesShouldSpawn;
        event Action Ticked;
        
        float Time { get; }
        
        void Start();
        void Stop();
    }
}