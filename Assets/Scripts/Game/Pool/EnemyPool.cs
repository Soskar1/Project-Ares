using Core.Entities;
using UnityEngine;

namespace Core
{
    public class EnemyPool
    {
        private Pool<BaseEnemy> _pool;

        public EnemyPool() => _pool = new Pool<BaseEnemy>(CreateObjectInPool, GetObjectFromPool, ReleaseObject, DestroyObject, PredicateObject);

        private BaseEnemy CreateObjectInPool(BaseEnemy arg)
        {
            var instance = Object.Instantiate(arg);
            return instance;
        }

        private void GetObjectFromPool(BaseEnemy obj) => obj.gameObject.SetActive(true);
        private void ReleaseObject(BaseEnemy obj) => obj.gameObject.SetActive(false);
        private void DestroyObject(BaseEnemy obj) => Object.Destroy(obj.gameObject);

        private bool PredicateObject(BaseEnemy obj, BaseEnemy instance)
        {
            return obj.ID == instance.ID;
        }

        public T Get<T>(T obj) where T : BaseEnemy
        {
            return (T)_pool.Get(obj);
        }

        public void Release<T>(T obj) where T : BaseEnemy => _pool.Release(obj);
    }
}