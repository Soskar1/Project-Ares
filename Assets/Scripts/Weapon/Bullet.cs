using UnityEngine;

namespace Core.Weapons
{
    public class Bullet : BaseBullet
    {
        private void Update() => transform.Translate(Vector2.right * _speed * Time.deltaTime);

        public override void Shot(Pool<BaseBullet> bulletPool, BulletStats bulletStats, LayerMask bulletType, float rotZ = 0)
        {
            base.Shot(bulletPool, bulletStats, bulletType, rotZ);
            transform.Rotate(new Vector3(0,0, rotZ));
        }
    }
}