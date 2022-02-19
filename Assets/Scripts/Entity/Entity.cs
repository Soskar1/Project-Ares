using UnityEngine;

namespace Core.Entities
{
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(Shooting))]
    public class Entity : MonoBehaviour
    {
        protected IMovement _movement;
        [SerializeField] protected Health _health;
        [SerializeField] protected Shooting _shooting;

        public Health Health { get => _health; }

        private void Awake() => _movement = GetComponent<IMovement>();
    }
}