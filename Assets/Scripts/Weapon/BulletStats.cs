namespace Core.Weapons
{
    public struct BulletStats
    {
        public float damage;
        public float speed;
        public float lifeTime;

        public BulletStats(float damage, float speed, float lifeTime = 2)
        {
            this.damage = damage;
            this.speed = speed;
            this.lifeTime = lifeTime;
        }
    }
}