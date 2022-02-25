using Core.Weapons;
using Object = UnityEngine.Object;

namespace Core
{
    public class BulletPool
    {
        private PoolObject<BaseBullet> _pool;

        public BulletPool()
        {
            _pool = new PoolObject<BaseBullet>(CreateBulletInPool, GetBullet, ReleaseBullet, DestroyBullet, PredicateBullet);
        }

        private BaseBullet CreateBulletInPool(BaseBullet arg)
        {
            var instance = Object.Instantiate(arg);
            instance.name = arg.name;
            return instance;
        }

        private void GetBullet(BaseBullet obj)
        {
            obj.gameObject.SetActive(true);
        }
        
        private void ReleaseBullet(BaseBullet obj)
        {
            obj.gameObject.SetActive(false);
        }

        private void DestroyBullet(BaseBullet obj)
        {
            Object.Destroy(obj.gameObject);
        }

        public T Get<T>(T obj) where T : BaseBullet
        {
            UnityEngine.Debug.Log("Get: " + obj.name);
            return (T)_pool.Get(obj);
        }

        public void Release<T>(T obj) where T : BaseBullet
        {
            UnityEngine.Debug.Log("Release: " + obj.name);
            _pool.Release(obj);
        }

        private bool PredicateBullet(BaseBullet obj, BaseBullet instance)
        {
            return obj.name == instance.name;
        }
    }
}