using UnityEngine;
using System;

namespace Core.Entities
{
    public class Health : MonoBehaviour, IDamage
    {
        [SerializeField] private float _maxHealth;
        private float _currentHealth;
        public float CurrentHealth { get => _currentHealth; }

        public event Action<float> OnChangeHealth;
        public event Action OnDeath;

        private void Awake() => _currentHealth = _maxHealth;

        public void OnHit(float damage)
        {
            _currentHealth -= damage;
            OnChangeHealth?.Invoke(_currentHealth);

            if (_currentHealth <= 0)
            {
                //пул
                OnDeath?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}