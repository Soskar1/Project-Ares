using Core.Entities;
using UnityEngine;

namespace Core.Weapons
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime;
        public BulletType type;

        private void OnEnable()
        {
            if (Pool<Bullet>.pool != null)
            {
                StartCoroutine(Timer.Start(_lifeTime, () => { Pool<Bullet>.pool.Release(this); }));
            }
            else
            {
                Debug.LogWarning("Pool<Bullet>.pool не был найден, поэтому объект будет уничтожен!");
                Destroy(gameObject, _lifeTime);
            }
        }

        private void Update() => transform.Translate(Vector2.right * _speed * Time.deltaTime);

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IHittable target))
            {
                if (collision.GetComponent<Player>() != null && type == BulletType.Enemy ||
                    collision.GetComponent<Enemy>() != null && type == BulletType.Ally)
                {
                    target.Hit(_damage);
                    Pool<Bullet>.pool.Release(this);
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