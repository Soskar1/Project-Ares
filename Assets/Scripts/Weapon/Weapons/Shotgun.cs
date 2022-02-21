using UnityEngine;

namespace Core.Weapons
{
    public class Shotgun : Weapon
    {
        [SerializeField] private int _bulletCount;
        [Range(0, 25f)] [SerializeField] private float _spread;

        public override void Fire()
        {
            for (int index = 0; index < _bulletCount; index++)
                CreateBullet();
        }

        private void CreateBullet()
        {
            BaseBullet bullet = _bulletPool.GetObjectFromPool();
            bullet.transform.position = _shotPos.position;
            bullet.transform.rotation = _shotPos.rotation;

            float rotZ = Random.Range(-_spread, _spread);
            bullet.Shot(_bulletPool, _bulletStats, _target, rotZ);
        }
    }
}