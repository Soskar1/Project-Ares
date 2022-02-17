using UnityEngine;
using UnityEngine.Pool;

namespace Core
{
    public static class Pool<T> where T : MonoBehaviour
    {
        public static ObjectPool<T> pool;

        public static void Create(T poolObject, bool collectionCheck = true, int defaultCapacity = 10, int maxSize = 1000)
        {
            pool = new ObjectPool<T>(() => GameObject.Instantiate(poolObject),
                actionOnGet => { actionOnGet.gameObject.SetActive(true); },
                actionOnRelease => { actionOnRelease.gameObject.SetActive(false); },
                actionOnDestroy => { Object.Destroy(actionOnDestroy.gameObject); },
                collectionCheck, defaultCapacity, maxSize);
        }
    }
}