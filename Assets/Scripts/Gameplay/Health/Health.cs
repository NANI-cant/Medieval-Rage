using System;
using Gameplay.Fighting;
using UnityEngine;

namespace Gameplay.Health{
	public class Health : MonoBehaviour, IHealth{
		public event Action<TakeHitResult> HitTaken;
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

		public void TakeHit(IReadOnlyAttackData attackData, MonoBehaviour damageDealer) {
			CurrentHealth -= attackData.Damage;
			HitTaken?.Invoke(new TakeHitResult(MaxHealth, CurrentHealth, attackData.Damage, damageDealer));

			if (CurrentHealth <= 0) Died?.Invoke();
		}
	}
}