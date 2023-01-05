using Gameplay.Setup;
using UnityEngine;

namespace Architecture.Services.Network {
    public interface INetworkPrefabProvider {
        GameObject Player { get; }
    }
}