using UnityEngine;

namespace Core.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [Header("Weapon")]
        [SerializeField] protected BaseBullet _bullet;
        [SerializeField] protected LayerMask _target;
        [SerializeField] protected Transform _shotPos;
        [SerializeField] protected BulletStats _bulletStats;

        protected Pool<BaseBullet> _bulletPool;

        public void Initialize(Pool<BaseBullet> bulletPool) => _bulletPool = bulletPool;

        public abstract void Fire();
    }
}