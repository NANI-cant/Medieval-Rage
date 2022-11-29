using Gameplay.Fighting;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI {
    public class HealthView: MonoBehaviour {
        [SerializeField] private Slider _slider;

        private Camera _camera;
        private Health.Health _trackedHealth;

        private void Awake() {
            _camera = Camera.main;
            _trackedHealth = GetComponentInParent<Health.Health>();
            _trackedHealth.HitTaked += UpdateSlider;
        }

        private void OnEnable() => SetupSlider(_trackedHealth.CurrentHealth);
        private void Start() => SetupSlider(_trackedHealth.CurrentHealth);
        private void OnDestroy() => _trackedHealth.HitTaked -= UpdateSlider;
        private void Update() => LookAtCamera();

        private void LookAtCamera() => transform.forward = (_camera.transform.position - transform.position).normalized;

        private void SetupSlider(float maxHealth) {
            _slider.maxValue = maxHealth;
            _slider.value = maxHealth;
        }

        private void UpdateSlider(TakeHitResult hitResult) {
            _slider.maxValue = hitResult.MaxHealth;
            _slider.value = hitResult.CurrentHealth;
        }

#if UNITY_EDITOR
        private void OnValidate() {
            if(_slider != null) return;
            _slider = GetComponentInChildren<Slider>();
        }
#endif
    }
}