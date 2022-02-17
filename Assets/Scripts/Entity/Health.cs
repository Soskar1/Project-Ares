using UnityEngine;
using System;

namespace Core.Entities
{
    public class Health : MonoBehaviour, IHittable
    {
        [SerializeField] private float _maxHealth;
        private float _currentHealth;
        public float CurrentHealth { get => _currentHealth; }

        [SerializeField] private bool _inPool = true;

        public event Action<float> OnChangeHealth;
        public event Action OnDeath;

        private void OnEnable() => _currentHealth = _maxHealth;

        public void Hit(float damage)
        {
            _currentHealth -= damage;
            OnChangeHealth?.Invoke(_currentHealth);

            if (_currentHealth <= 0)
            {
                OnDeath?.Invoke();

                if (_inPool)
                    Pool<Entity>.pool.Release(GetComponent<Entity>());
                else
                    Destroy(gameObject);
            }
        }
    }
}