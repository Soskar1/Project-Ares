using UnityEngine;
using UnityEngine.Pool;

namespace Core
{
    public static class Pool<T> where T : MonoBehaviour
    {
        public static ObjectPool<T> pool;

        public static void Create(T poolObject, bool collectionCheck = true, int defaultCapacity = 10, int maxSize = 1000)
        {
            pool = new ObjectPool<T>(() => CreateInPool(poolObject), Get, Release, DestroyPoolObject,
                collectionCheck, defaultCapacity, maxSize);
        }

        private static T CreateInPool(T poolObject)
        {
            return GameObject.Instantiate(poolObject);
        }

        private static void Get(T poolObject) => poolObject.gameObject.SetActive(true);

        private static void Release(T poolObject) => poolObject.gameObject.SetActive(false);

        private static void DestroyPoolObject(T poolObject) => Object.Destroy(poolObject.gameObject);
    }
}