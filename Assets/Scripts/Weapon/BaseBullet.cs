using Core.Entities;
using UnityEngine;

namespace Core.Weapons
{
    public abstract class BaseBullet : MonoBehaviour
    {
        [SerializeField] private float _damage;
        [SerializeField] protected float _speed;
        [SerializeField] private float _lifeTime;
        private LayerMask _target;
        private Pool<BaseBullet> _pool;

        public virtual void Shot(Pool<BaseBullet> bulletPool, BulletStats bulletStats, LayerMask target, float rotZ = 0)
        {
            _pool = bulletPool;

            _damage = bulletStats.damage;
            _speed = bulletStats.speed;
            _lifeTime = bulletStats.lifeTime;
            _target = target;

            StartCoroutine(Timer.Start(_lifeTime, () => { _pool.ReleaseObject(this); }));
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IHittable target))
            {
                if (collision.GetComponent<Entity>().Layer != _target)
                    return;

                target.Hit(_damage);
                _pool.ReleaseObject(this);
            }
        }
    }
}