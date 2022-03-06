using UnityEngine;
using System;

namespace Core.Entities
{
    public class Health : MonoBehaviour, IHittable
    {
        [SerializeField] private Shooting _shooting;
        [SerializeField] private float _maxHealth;
        private float _currentHealth;
        private bool _isDead = false;

        public float MaxHealth { get { return _maxHealth; } set { _maxHealth = value; _currentHealth = _maxHealth; } }

        public delegate bool ConditionCheck();
        public ConditionCheck OnConditionCheck;

        public event Action<float> OnChangeHealth;
        public event Action OnHit;
        public event Action OnDeath;

        private void OnEnable() => Reset();

        public void Hit(float damage)
        {
            if (OnConditionCheck != null)
                if (OnConditionCheck.Invoke())
                    return;

            OnHit?.Invoke();

            if (_shooting.CurrentWeapon.Level > 1)
            {
                _shooting.CurrentWeapon.Degrade();
                return;
            }

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