namespace Core.Weapons
{
    public class StraightLineGun : Weapon
    {
        private void Awake()
        {
            if (Pool<Bullet>.pool == null)
                Pool<Bullet>.Create(_bullet);
        }

        public override void Fire()
        {
            Bullet projectile = Pool<Bullet>.pool.Get();
            projectile.transform.position = _shotPos.position;
            projectile.transform.rotation = _shotPos.rotation;
        }
    }
}