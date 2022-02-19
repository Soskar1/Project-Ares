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

        [Header("Bullet Stats")]
        [SerializeField] private float _damage;
        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime;

        private void Awake() => _bulletStats = new BulletStats(_damage, _speed, _lifeTime);

        public abstract void Fire();
    }
}