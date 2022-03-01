using System;
using UnityEngine;

namespace Core.Weapons
{
    [Serializable]
    public struct BulletStats
    {
        public float damage;
        public float speed;
        public float lifeTime;
        public Color color;
    }
}