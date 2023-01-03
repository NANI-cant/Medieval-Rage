using UnityEngine;

namespace Architecture.Services.AssetProviding {
    public interface IUIProvider {
        GameObject HUD { get; }
        GameObject EndGamePanel { get; }
    }
}
