using UnityEngine;
using TMPro;
using Core.Entities;

namespace Core.UI
{
    public class PlayerHealthHUD : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _healthText;

        public void Initialize(Health health)
        {
            health.OnChangeHealth += ChangeText;
            ChangeText(health.MaxHealth);
        }

        public void Disable(Health health) => health.OnChangeHealth -= ChangeText;

        private void ChangeText(float currentHealth) => _healthText.SetText("HP: " + currentHealth.ToString());
    }
}