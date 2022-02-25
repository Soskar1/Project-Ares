using UnityEngine;

namespace Core.Entities
{
    [RequireComponent(typeof(Health))]
    public abstract class Entity : MonoBehaviour
    {
        private IMovement _movement;
        [SerializeField] private Health _health;
        [SerializeField] private Shooting _shooting;
        [SerializeField] private LayerMask _layer;

        public IMovement Movement => _movement;
        public Health Health => _health;
        public LayerMask Layer => _layer;

        private void Awake() => _movement = GetComponent<IMovement>();
        private void OnEnable() => _health.OnDeath += Death;
        private void OnDisable() => _health.OnDeath -= Death;

        public void Initialize(BulletPool bulletPool, EffectsPool effectsPool) => _shooting.Initialize(bulletPool, effectsPool);

        public virtual void Death() => gameObject.SetActive(false);
    }
}