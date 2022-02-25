using Core.Weapons;
using UnityEngine;

namespace Core
{
    public class BulletPool
    {
        private Pool<BaseBullet> _pool;

        public BulletPool() => _pool = new Pool<BaseBullet>(CreateObjectInPool, GetObjectFromPool, ReleaseObject, DestroyObject, PredicateObject);

        private BaseBullet CreateObjectInPool(BaseBullet arg)
        {
            var instance = Object.Instantiate(arg);
            return instance;
        }

        private void GetObjectFromPool(BaseBullet obj) => obj.gameObject.SetActive(true);
        private void ReleaseObject(BaseBullet obj) => obj.gameObject.SetActive(false);
        private void DestroyObject(BaseBullet obj) => Object.Destroy(obj.gameObject);

        private bool PredicateObject(BaseBullet obj, BaseBullet instance)
        {
            return obj.ID == instance.ID;
        }

        public T Get<T>(T obj) where T : BaseBullet
        {
            return (T)_pool.Get(obj);
        }

        public void Release<T>(T obj) where T : BaseBullet => _pool.Release(obj);
    }
}