using UnityEngine;

namespace Core.Weapons
{
    public class Shotgun : Weapon
    {
        [SerializeField] private int _bulletCount;
        [Range(0, 25f)] [SerializeField] private float _spread;

        private void Awake()
        {
            if (Pool<BaseBullet>.pool == null)
                Pool<BaseBullet>.Create(_bullet);
        }

        public override void Fire()
        {
            for (int index = 0; index < _bulletCount; index++)
                CreateBullet();
        }

        private void CreateBullet()
        {
            BaseBullet bullet = Pool<BaseBullet>.pool.Get();
            bullet.transform.position = _shotPos.position;
            bullet.transform.rotation = _shotPos.rotation;

            float rotZ = Random.Range(-_spread, _spread);
            bullet.Shot(_bulletType, rotZ);
        }
    }
}