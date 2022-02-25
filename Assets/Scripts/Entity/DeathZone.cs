using UnityEngine;

namespace Core.Entities
{
    public class DeathZone : MonoBehaviour
    {
        private EnemyPool _pool;

        public void Initialize(EnemyPool enemyPool) => _pool = enemyPool;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out BaseEnemy entity))
                _pool.Release(entity);
        }
    }
}