using UnityEngine;

namespace Core.Entities
{
    [RequireComponent(typeof(Health))]
    public abstract class Entity : MonoBehaviour
    {
        private IMovement _movement;
        [SerializeField] private Health _health;
        [SerializeField] private LayerMask _layer;

        public IMovement Movement => _movement;
        public Health Health => _health;
        public LayerMask Layer => _layer;

        private void Awake() => _movement = GetComponent<IMovement>();
        private void OnEnable() => _health.OnDeath += Death;
        private void OnDisable() => _health.OnDeath -= Death;

        public virtual void Death() => gameObject.SetActive(false);
    }
}