using UnityEngine;

namespace Core.Entities
{
    public class DeathZone : MonoBehaviour
    {
        private Pool<BaseEnemy> pool;

        public void Initialize(Pool<BaseEnemy> enemyPool) => pool = enemyPool;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out BaseEnemy entity))
                pool.ReleaseObject(entity);
        }
    }
}