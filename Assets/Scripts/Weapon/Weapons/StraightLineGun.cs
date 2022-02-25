namespace Core.Weapons
{
    public class StraightLineGun : Weapon
    {
        public override void Fire()
        {
            BaseBullet bullet = _bulletPool.Get(_bullet);
            bullet.transform.position = _shotPos.position;
            bullet.transform.rotation = _shotPos.rotation;

            bullet.Shot(_bulletPool, _effectsPool, _bulletStats, _target);
        }
    }
}