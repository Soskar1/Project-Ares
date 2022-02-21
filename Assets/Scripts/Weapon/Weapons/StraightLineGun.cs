namespace Core.Weapons
{
    public class StraightLineGun : Weapon
    {
        public override void Fire()
        {
            BaseBullet bullet = _bulletPool.GetObjectFromPool();
            bullet.transform.position = _shotPos.position;
            bullet.transform.rotation = _shotPos.rotation;

            bullet.Shot(_bulletPool, _bulletStats, _target);
        }
    }
}