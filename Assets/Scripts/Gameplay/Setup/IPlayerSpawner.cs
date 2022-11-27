using Architecture.Services;
using UnityEngine;

namespace Gameplay.Setup {
    public interface IPlayerSpawner: ISpawnPoint {
        void TrackPlayer(GameObject player, IResetUnitService resetService);
    }
}
