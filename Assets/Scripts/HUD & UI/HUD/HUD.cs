using Core.Entities;
using UnityEngine;

namespace Core.HUD
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private HealthHUD _healthHUD;
        [SerializeField] private Health _health;

        private void Start() => _healthHUD.Initialize(_health);
        private void OnDisable() => _healthHUD.Disable(_health);
    }
}