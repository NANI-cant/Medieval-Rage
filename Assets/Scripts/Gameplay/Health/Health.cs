using System;
using Gameplay.Fighting;
using UnityEngine;

namespace Gameplay.Health{
	public class Health : MonoBehaviour, IDamageable{
		private float _maxHealth;
		private float _health;

		public event Action<TakeHitResult> HitTaked;

		public void Construct(float maxHealth) {
			_maxHealth = maxHealth;
			_health = _maxHealth;
		}

		public void TakeHit(IReadOnlyAttackData attackData) {
			_health -= attackData.Damage;
			HitTaked?.Invoke(new TakeHitResult(_maxHealth, _health, attackData.Damage));
		}
	}
}