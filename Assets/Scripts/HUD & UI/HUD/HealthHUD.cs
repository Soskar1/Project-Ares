using UnityEngine;
using TMPro;
using Core.Entities;

namespace Core.HUD
{
    public class HealthHUD : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _healthText;

        public void Initialize(Health health)
        {
            health.OnChangeHealth += Edit;
            Edit(health.CurrentHealth);
        }

        public void Disable(Health health) => health.OnChangeHealth -= Edit;

        private void Edit(float currentHealth) => _healthText.SetText("HP: " + currentHealth.ToString());
    }
}