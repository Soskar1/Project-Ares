using UnityEngine;

namespace Core.Entities
{
    public abstract class BaseEnemy : Entity, IPooledObject
    {
        private EnemyPool _pool;

        [Range(0, 100)][SerializeField] private float _spawnFrequency;
        [SerializeField] private int _poolID;
        public int ID => _poolID;
        public float SpawnFrequency => _spawnFrequency;

        public void Initialize(EnemyStats stats, EnemyPool enemyPool, BulletPool bulletPool, EffectsPool effectsPool)
        {
            Health.MaxHealth = stats.maxHealth;
            Movement.Speed = stats.speed;

            _pool = enemyPool;
            Initialize(bulletPool, effectsPool);
        }

        public override void Death() => _pool.Release(this);
    }
}