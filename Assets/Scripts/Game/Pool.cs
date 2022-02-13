using Core.Weapons;
using UnityEngine;
using UnityEngine.Pool;

namespace Core
{
    public class Pool : MonoBehaviour
    {
        [SerializeField] private Projectile _projectile;
        public ObjectPool<Projectile> projectilePool;

        private void Awake()
        {
            projectilePool = new ObjectPool<Projectile>(Create, OnGet, OnRelease, OnDestroyPoolObject, true, 100, 200);
        }

        private Projectile Create()
        {
            Projectile projectile = Instantiate(_projectile, transform.position, Quaternion.identity);
            projectile.transform.parent = transform;
            return projectile;
        }

        private void OnGet(Projectile projectile) => projectile.gameObject.SetActive(true);
        private void OnRelease(Projectile projectile) => projectile.gameObject.SetActive(false);
        private void OnDestroyPoolObject(Projectile projectile) => Destroy(projectile.gameObject);
    }
}