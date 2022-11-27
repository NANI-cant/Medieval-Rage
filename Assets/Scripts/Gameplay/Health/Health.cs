using System;
using Gameplay.Fighting;
using UnityEngine;

namespace Gameplay.Health{
	public class Health : MonoBehaviour, IDamageable{
		public event Action<TakeHitResult> HitTaked;
		public event Action Died;
		
		public float MaxHealth { get; private set; }
		public float CurrentHealth { get; private set; }

		public void Construct(float maxHealth) {
			MaxHealth = maxHealth;
			CurrentHealth = MaxHealth;
		}
		
		public void ResetToDefault(float maxHealth) {
			MaxHealth = maxHealth;
			CurrentHealth = MaxHealth;
		}

		public void TakeHit(IReadOnlyAttackData attackData) {
			CurrentHealth -= attackData.Damage;
			HitTaked?.Invoke(new TakeHitResult(MaxHealth, CurrentHealth, attackData.Damage));

			if (CurrentHealth <= 0) Died?.Invoke();
		}
	}
}