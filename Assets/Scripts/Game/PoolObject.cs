using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class PoolObject<T> where T : MonoBehaviour
    {
        private List<T> _pool;

        private readonly Func<T, T, bool> _predicate;

        private readonly Func<T, T> _createFunction;
        private readonly Action<T> _getAction;
        private readonly Action<T> _releaseAction;
        private readonly Action<T> _destroyAction;
        private readonly int _capacity;

        public PoolObject(Func<T, T> create, Action<T> get, Action<T> release, Action<T> destroy, Func<T, T, bool> predicate, int capacity = 50)
        {
            _createFunction = create;
            _getAction = get;
            _releaseAction = release;
            _destroyAction = destroy;
            _predicate = predicate;
            _capacity = capacity;

            _pool = new List<T>();
        }

        public T Get(T obj)
        {
            Debug.Log("Get In Pool: " + obj.name);

            for (int index = 0; index < _pool.Count; index++)
            {
                var instance = _pool[index];
                Debug.Log("Instance: " + instance.name);
                if (instance == null)
                {
                    _pool.RemoveAt(index);
                    index--;
                    continue;
                }

                if (_predicate.Invoke(obj, instance))
                {
                    _pool.RemoveAt(index);
                    _getAction?.Invoke(instance);
                    return instance;
                }
            }

            return _createFunction?.Invoke(obj);
        }

        public void Release(T obj)
        {
            if (_pool.Count < _capacity)
            {
                _releaseAction?.Invoke(obj);
                _pool.Add(obj);
            }
            else
            {
                _destroyAction?.Invoke(obj);
            }
        }

        public void Clear()
        {
            foreach(var obj in _pool)
            {
                if (obj == null)
                    continue;

                _destroyAction(obj);
            }

            _pool.Clear();
        }
    }
}