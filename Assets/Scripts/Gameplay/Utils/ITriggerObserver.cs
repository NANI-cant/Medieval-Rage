using System;
using UnityEngine;

namespace Gameplay.Utils {
    public interface ITriggerObserver {
        event Action<Collider> Enter;
        event Action<Collider> Exit;
    }
}