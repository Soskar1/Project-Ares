using UnityEngine;

namespace Core.Weapons
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private BulletPool _pool;
        [SerializeField] private float _damage;
        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime;

        private void OnEnable() => StartCoroutine(Timer.Start(_lifeTime, () => { _pool.bulletPool.Release(this); }));
        private void Update() => transform.Translate(Vector2.right * _speed * Time.deltaTime);

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IDamage target))
            {
                Debug.Log(collision.name);
                target.OnHit(_damage);
            }
        }
    }
}