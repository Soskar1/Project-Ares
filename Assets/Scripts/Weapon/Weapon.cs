using UnityEngine;

namespace Core.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected Bullet _bullet;
        [SerializeField] protected BulletType _bulletType;
        [SerializeField] protected Transform _shotPos;
        public float delay;

        public abstract void Fire();
    }
}