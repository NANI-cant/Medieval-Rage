using System;
using UnityEngine;

namespace Gameplay.Fighting {
    public interface IDamageable{
        public event Action<TakeHitResult> HitTaken;
        void TakeHit(IReadOnlyAttackData attackData, MonoBehaviour damageDealer);
    }
}