using Core.Entities;
using UnityEngine;
using UnityEngine.Pool;

namespace Core
{
    public class EnemyPool : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;
        public ObjectPool<Enemy> enemyPool;

        private void Awake()
        {
            enemyPool = new ObjectPool<Enemy>(Create, OnGet, OnRelease, OnDestroyPoolObject, true, 25, 50);
        }

        private Enemy Create()
        {
            Enemy enemy = Instantiate(_enemy, transform.position, Quaternion.identity);
            enemy.transform.parent = transform;
            return enemy;
        }

        private void OnGet(Enemy projectile)
        {
            projectile.gameObject.SetActive(true);
        }
        private void OnRelease(Enemy projectile)
        {
            projectile.gameObject.SetActive(false);
        }

        private void OnDestroyPoolObject(Enemy projectile) => Destroy(projectile.gameObject);
    }
}
