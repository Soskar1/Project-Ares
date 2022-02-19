using UnityEngine;

namespace Core.Entities
{
    public class Enemy : BaseEnemy
    {
        private void FixedUpdate()
        {
            if (_movement != null)
                _movement.Move(Vector2.left);
        }
    }
}