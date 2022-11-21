using System;
using UnityEngine;

namespace Gameplay.Fighting {
    [Serializable]
    public struct AttackData: IReadOnlyAttackData{
        [field: SerializeField] public float Damage { get; set; }
    }
}