using System;
using UnityEngine;

namespace Core.Collectibles
{
    public class Collectible : MonoBehaviour, ICollectible
    {
        public void Collect(Action Collected) => Collected.Invoke();
    }
}