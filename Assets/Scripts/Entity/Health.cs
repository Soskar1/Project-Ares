using UnityEngine;
using System;

namespace Core.Entities
{
    public class Health : MonoBehaviour, IHittable
    {
        [SerializeField] private float _maxHealth;
        private float _currentHealth;
        private bool _isDead = false;

        public float MaxHealth => _maxHealth;

        public event Action<float> OnChangeHealth;
        public event Action OnDeath;

        private void OnEnable() => Reset();

        public void Hit(float damage)
        {
            _currentHealth -= damage;
            OnChangeHealth?.Invoke(_currentHealth);

            if (_currentHealth <= 0)
                Death();
        }

        private void Death()
        {
            if (_isDead)
                return;

            _isDead = true;
            OnDeath?.Invoke();
        }

        private void Reset()
        {
            _currentHealth = _maxHealth;
            _isDead = false;
        }
    }
}