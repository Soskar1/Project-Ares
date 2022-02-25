using Core.Entities;
using UnityEngine;

namespace Core.Weapons
{
    public abstract class BaseBullet : MonoBehaviour
    {
        private float _damage;
        protected float _speed;
        private float _lifeTime;
        private LayerMask _target;
        private BulletPool _pool;
        public int ID;

        public virtual void Shot(BulletPool bulletPool, BulletStats bulletStats, LayerMask target, float rotZ = 0)
        {
            _pool = bulletPool;

            _damage = bulletStats.damage;
            _speed = bulletStats.speed;
            _lifeTime = bulletStats.lifeTime;
            _target = target;

            StartCoroutine(Timer.Start(_lifeTime, () => { _pool.Release(this); }));
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IHittable target))
            {
                if (collision.GetComponent<Entity>().Layer != _target)
                    return;

                target.Hit(_damage);
                _pool.Release(this);
            }
        }
    }
}