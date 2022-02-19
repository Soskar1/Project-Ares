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

        public virtual void Shot(BulletStats bulletStats, LayerMask target, float rotZ = 0)
        {
            _damage = bulletStats.damage;
            _speed = bulletStats.speed;
            _lifeTime = bulletStats.lifeTime;
            _target = target;

            StartCoroutine(Timer.Start(_lifeTime, () => { Pool<BaseBullet>.pool.Release(this); }));
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IHittable target))
            {
                if (collision.GetComponent<Entity>().Layer != _target)
                    return;

                target.Hit(_damage);
                Pool<BaseBullet>.pool.Release(this);
            }
        }
    }
}