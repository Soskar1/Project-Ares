using UnityEngine;

public class Enemy : Entity
{
    private void FixedUpdate()
    {
        if (_movement != null)
            _movement.Move(Vector2.left);
    }
}
