using UnityEngine;

namespace Core.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected Pool _pool;
        [SerializeField] protected Transform _shotPos;
        public float maxTime;

        public abstract void Fire();
    }
}