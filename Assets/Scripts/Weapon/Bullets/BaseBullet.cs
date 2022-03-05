using Core.Entities;
using UnityEngine;

namespace Core.Weapons
{
    public abstract class BaseBullet : MonoBehaviour, IPooledObject
    {
        protected float _speed;
        private float _damage;
        private float _lifeTime;
        private LayerMask _target;

        private BulletPool _bulletPool;
        protected EffectsPool _effectsPool;

        [SerializeField] private TrailRenderer _trailRenderer;
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private int _poolID;
        public int ID => _poolID;

        public virtual void Shot(BulletPool bulletPool, EffectsPool effectsPool, BulletStats bulletStats, LayerMask target, float rotZ = 0)
        {
            _bulletPool = bulletPool;
            _effectsPool = effectsPool;

            _damage = bulletStats.damage;
            _speed = bulletStats.speed;
            _lifeTime = bulletStats.lifeTime;
            _renderer.color = bulletStats.color;
            _target = target;

            StartCoroutine(Timer.Start(_lifeTime, () => { _bulletPool.Release(this); }));
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IHittable target))
            {
                if (collision.GetComponent<Entity>().Layer != _target)
                    return;

                target.Hit(_damage);
                _bulletPool.Release(this);
            }
        }

        public void ResetTrail() => _trailRenderer.Clear();
    }
}