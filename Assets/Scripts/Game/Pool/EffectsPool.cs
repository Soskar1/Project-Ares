using Core.Effects;
using UnityEngine;

namespace Core
{
    public class EffectsPool
    {
        private Pool<Effect> _pool;

        public EffectsPool() => _pool = new Pool<Effect>(CreateObjectInPool, GetObjectFromPool, ReleaseObject, DestroyObject, PredicateObject);

        private Effect CreateObjectInPool(Effect arg)
        {
            var instance = Object.Instantiate(arg);
            return instance;
        }

        private void GetObjectFromPool(Effect obj) => obj.gameObject.SetActive(true);
        private void ReleaseObject(Effect obj) => obj.gameObject.SetActive(false);
        private void DestroyObject(Effect obj) => Object.Destroy(obj.gameObject);

        private bool PredicateObject(Effect obj, Effect instance)
        {
            return obj.ID == instance.ID;
        }

        public T Get<T>(T obj) where T : Effect
        {
            return (T)_pool.Get(obj);
        }

        public void Release<T>(T obj) where T : Effect => _pool.Release(obj);
    }
}