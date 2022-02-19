using UnityEngine;

namespace Core.Entities
{
    [RequireComponent(typeof(Input))]
    public class Player : Entity
    {
        [SerializeField] private Input _input;

        private void OnEnable() => Health.OnDeath += Death;
        private void OnDisable() => Health.OnDeath -= Death;

        private void FixedUpdate()
        {
            if (_movement != null)
                _movement.Move(_input.MovementDirection);
        }

        private void Death() => Destroy(gameObject);
    }
}