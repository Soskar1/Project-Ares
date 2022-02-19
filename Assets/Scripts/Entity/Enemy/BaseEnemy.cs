namespace Core.Entities
{
    public abstract class BaseEnemy : Entity
    {
        public override void Death() => Pool<BaseEnemy>.pool.Release(this);
    }
}