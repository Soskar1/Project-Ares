using UnityEngine;
using UnityEngine.Pool;

namespace Core
{
    public class Pool<T> where T : MonoBehaviour
    {
        private ObjectPool<T> pool;

        public void Initialize(T poolObject, bool collectionCheck = true, int defaultCapacity = 10, int maxSize = 1000)
        {
            pool = new ObjectPool<T>(() => Create(poolObject), Get, Release, DestroyPoolObject,
                collectionCheck, defaultCapacity, maxSize);
        }

        private T Create(T poolObject)
        {
            return GameObject.Instantiate(poolObject);
        }

        private void Get(T poolObject) => poolObject.gameObject.SetActive(true);

        private void Release(T poolObject) => poolObject.gameObject.SetActive(false);

        private void DestroyPoolObject(T poolObject) => Object.Destroy(poolObject.gameObject);

        public T GetObjectFromPool()
        {
            return pool.Get();
        }

        public void ReleaseObject(T poolObject) => pool.Release(poolObject);
    }
}