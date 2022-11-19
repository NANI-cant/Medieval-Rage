using UnityEngine;

namespace Architecture.Services {
    public interface IGameplayFactory {
        GameObject CreatePlayerCharacter(Vector3 position, Quaternion rotation);
    }
}
