namespace Core.Weapons
{
    public class StraightLineGun : Weapon
    {
        public override void Fire()
        {
            Projectile projectile = _pool.projectilePool.Get();
            projectile.transform.position = _shotPos.position;
            projectile.transform.rotation = _shotPos.rotation;
        }
    }
}