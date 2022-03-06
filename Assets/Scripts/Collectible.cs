using System;
using UnityEngine;

namespace Core.Collectibles
{
    public class Collectible : MonoBehaviour, ICollectible, IPooledObject
    {
        [SerializeField] private int _poolID;
        public int ID => _poolID;

        public void Collect(Action Collected) => Collected.Invoke();
    }
}