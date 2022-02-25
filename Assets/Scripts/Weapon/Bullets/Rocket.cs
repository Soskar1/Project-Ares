using UnityEngine;

namespace Core.Weapons
{
    public class Rocket : BaseBullet
    {
        [SerializeField] private GameObject _explosion;

        public override void Shot(BulletPool bulletPool, BulletStats bulletStats, LayerMask bulletType, float rotZ = 0)
        {
            base.Shot(bulletPool, bulletStats, bulletType, rotZ);
        }

        private void OnDisable() => Explode();

        private void Explode() => Instantiate(_explosion, transform.position, Quaternion.identity);
    }
}
