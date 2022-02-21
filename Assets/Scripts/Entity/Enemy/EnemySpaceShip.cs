using UnityEngine;

namespace Core.Entities
{
    public class EnemySpaceShip : BaseEnemy
    {
        private void FixedUpdate()
        {
            if (Movement != null)
                Movement.Move(Vector2.left);
        }
    }
}