using UnityEngine;

public class Projectile : Weapon
{
    [SerializeField] private Pool _pool;
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;

    private void OnEnable() => StartCoroutine(Timer.Start(_lifeTime, () => { _pool.projectilePool.Release(this); }));
    private void Update() => transform.Translate(Vector2.right * _speed * Time.deltaTime);

    public override void Use()
    {
        
    }
}
