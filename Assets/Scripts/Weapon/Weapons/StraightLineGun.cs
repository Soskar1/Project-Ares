namespace Core.Weapons
{
    public class StraightLineGun : Weapon
    {
        public override void Fire()
        {
            Bullet projectile = _pool.bulletPool.Get();
            projectile.transform.position = _shotPos.position;
            projectile.transform.rotation = _shotPos.rotation;
        }
    }
}