using UnityEngine;

namespace Architecture.Services.Factories {
    public interface IUIFactory {
        GameObject CreateHUD();
        GameObject CreateEndGamePanel();
    }
}