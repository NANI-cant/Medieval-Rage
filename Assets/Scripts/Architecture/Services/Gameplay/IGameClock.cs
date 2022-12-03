using System;

namespace Architecture.Services.Gameplay {
    public interface IGameClock {
        event Action EnemiesShouldSpawn;
        event Action Ticked;
        
        float Time { get; }
        
        void Start();
        void Stop();
    }
}