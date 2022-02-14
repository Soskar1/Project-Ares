using Core.Weapons;
using UnityEngine;
using UnityEngine.Pool;

namespace Core
{
    public class BulletPool : MonoBehaviour
    {
        [SerializeField] private Bullet _bullet;
        public ObjectPool<Bullet> bulletPool;

        private void Awake()
        {
            bulletPool = new ObjectPool<Bullet>(Create, OnGet, OnRelease, OnDestroyPoolObject, true, 100, 200);
        }

        private Bullet Create()
        {
            Bullet bullet = Instantiate(_bullet, transform.position, Quaternion.identity);
            bullet.transform.parent = transform;
            return bullet;
        }

        private void OnGet(Bullet bullet) => bullet.gameObject.SetActive(true);
        private void OnRelease(Bullet bullet) => bullet.gameObject.SetActive(false);
        private void OnDestroyPoolObject(Bullet bullet) => Destroy(bullet.gameObject);
    }
}