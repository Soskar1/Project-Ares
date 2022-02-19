using Core.Entities;
using UnityEngine;

namespace Core.Weapons
{
    public abstract class BaseBullet : MonoBehaviour
    {
        [SerializeField] private float _damage;
        [SerializeField] protected float _speed;
        [SerializeField] private float _lifeTime;
        private BulletType _type;

        private void OnEnable()
        {
            if (Pool<BaseBullet>.pool != null)
            {
                StartCoroutine(Timer.Start(_lifeTime, () => { Pool<BaseBullet>.pool.Release(this); }));
            }
            else
            {
                Debug.LogWarning("Pool<BaseBullet>.pool не был найден, поэтому объект будет уничтожен!");
                Destroy(gameObject, _lifeTime);
            }
        }

        public virtual void Shot(BulletType bulletType, float rotZ = 0) => _type = bulletType;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IHittable target))
            {
                if (collision.GetComponent<Player>() != null && _type == BulletType.Enemy ||
                    collision.GetComponent<Enemy>() != null && _type == BulletType.Ally)
                {
                    target.Hit(_damage);
                    Pool<BaseBullet>.pool.Release(this);
                }
            }
        }
    }

    public enum BulletType
    {
        Ally,
        Enemy
    }
}