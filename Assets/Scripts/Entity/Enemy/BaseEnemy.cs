namespace Core.Entities
{
    public abstract class BaseEnemy : Entity
    {
        public void Initialize(EnemyStats stats)
        {
            Health.MaxHealth = stats.maxHealth;
            Movement.Speed = stats.speed;
        }

        public override void Death() => Pool<BaseEnemy>.pool.Release(this);
    }
}