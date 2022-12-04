using UnityEngine;

namespace Architecture.Services {
    public interface IUIProvider {
        GameObject HUD { get; }
        GameObject EndGamePanel { get; }
    }
}
