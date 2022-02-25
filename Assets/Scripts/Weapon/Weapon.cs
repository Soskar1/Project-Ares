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
        [SerializeField] private float _delay;

        protected BulletPool _bulletPool;
        public float Delay => _delay;
        public void Initialize(BulletPool bulletPool) => _bulletPool = bulletPool;

        public abstract void Fire();
    }
}