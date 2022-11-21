using Architecture.Services;
using Gameplay.Fighting;
using UnityEngine;
using Gameplay.Utils;

namespace Gameplay.Enemy{
	public class AutoAttacker : MonoBehaviour{
		private AttackData _attackData;
		private float _attackCooldown;
		private Timer _cooldownTimer;
		private ITimeProvider _timeProvider;

		public bool CanAttack { get; private set; }

		public void Construct(float attackCooldown, AttackData attackData, ITimeProvider timeProvider) {
			_attackCooldown = attackCooldown;
			_attackData = attackData;
			_timeProvider = timeProvider;
			CanAttack = true;
		}

		private void Update() {
			_cooldownTimer?.Tick(_timeProvider.DeltaTime);
		}

		public void Attack(IDamageable damageable){
			damageable.TakeHit(_attackData);
			
			CanAttack = false;
			_cooldownTimer = new Timer(_attackCooldown, () => CanAttack = true);
		}
	}
}