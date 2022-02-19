using UnityEngine;

namespace Core.Entities
{
    public class Enemy : Entity
    {
        private void OnEnable() => _health.OnDeath += Death;

        private void OnDisable() => _health.OnDeath -= Death;

        private void FixedUpdate()
        {
            if (_movement != null)
                _movement.Move(Vector2.left);
        }

        private void Death() => Pool<Entity>.pool.Release(this);
    }
}