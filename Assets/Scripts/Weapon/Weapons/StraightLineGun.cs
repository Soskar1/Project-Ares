namespace Core.Weapons
{
    public class StraightLineGun : Weapon
    {
        public override void Fire()
        {
            BaseBullet bullet = Pool<BaseBullet>.pool.Get();
            bullet.transform.position = _shotPos.position;
            bullet.transform.rotation = _shotPos.rotation;

            bullet.Shot(_bulletStats, _target);
        }
    }
}