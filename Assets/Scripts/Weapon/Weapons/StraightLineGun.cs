namespace Core.Weapons
{
    public class StraightLineGun : Weapon
    {
        private void Awake()
        {
            if (Pool<BaseBullet>.pool == null)
                Pool<BaseBullet>.Create(_bullet);
        }

        public override void Fire()
        {
            BaseBullet bullet = Pool<BaseBullet>.pool.Get();
            bullet.transform.position = _shotPos.position;
            bullet.transform.rotation = _shotPos.rotation;

            bullet.Shot(_bulletType);
        }
    }
}