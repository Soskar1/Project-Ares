using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Pool _pool;
    [SerializeField] private Transform _shotPoint;

    protected void Shoot()
    {
        Projectile projectile = _pool.projectilePool.Get();
        projectile.transform.position = _shotPoint.position;
        projectile.transform.rotation = _shotPoint.rotation;
    }
}
