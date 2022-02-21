using Core.Weapons;

namespace Core.Entities
{
    public abstract class BaseEnemy : Entity
    {
        private Pool<BaseEnemy> _pool;

        public void Initialize(EnemyStats stats, Pool<BaseEnemy> enemyPool, Pool<BaseBullet> bulletPool)
        {
            Health.MaxHealth = stats.maxHealth;
            Movement.Speed = stats.speed;

            _pool = enemyPool;
            Initialize(bulletPool);
        }

        public override void Death() => _pool.ReleaseObject(this);
    }
}