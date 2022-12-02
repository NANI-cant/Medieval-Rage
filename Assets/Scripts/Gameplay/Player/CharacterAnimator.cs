using Architecture.Services;
using Architecture.Services.General;
using UnityEngine;

namespace Gameplay.Player {
    public class CharacterAnimator : MonoBehaviour {
        private const string SpeedParameter = "Speed";
        private const string AttackSpeedParameter = "AttackSpeed";
        private const string InterruptTrigger = "Interrupt";

        [SerializeField] private Animator _animator;

        private IRandomService _randomService;

        protected string[] AttackStates = new[] {
            "Attack1",
            "Attack2",
            "Attack3"
        };

        public float Speed {
            get => _animator.GetFloat(SpeedParameter);
            set => _animator.SetFloat(SpeedParameter, Mathf.Clamp01(value));
        }

        public float AttackSpeed {
            get => _animator.GetFloat(AttackSpeedParameter);
            set => _animator.SetFloat(AttackSpeedParameter, value);
        }
        
        public virtual void Construct(float attackSpeed, IRandomService randomService) {
            AttackSpeed = attackSpeed;
            _randomService = randomService;
        }
        
        public virtual void ResetToDefault(float attackSpeed) {
            AttackSpeed = attackSpeed;
        }

        public void PlayAttack() {
            int randomIndex = _randomService.Range(0, AttackStates.Length);
            string attackState = AttackStates[randomIndex];
            _animator.Play(attackState);
        }

        public void Interrupt() {
            _animator.SetTrigger(InterruptTrigger);
        }
    }
}
