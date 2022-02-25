using Core.Effects;
using UnityEngine;

namespace Core.Weapons
{
    public class Rocket : BaseBullet
    {
        [SerializeField] private Effect _effect;

        private void Update() => transform.Translate(Vector2.right * _speed * Time.deltaTime);

        public override void Shot(BulletPool bulletPool, EffectsPool effectsPool, BulletStats bulletStats, LayerMask bulletType, float rotZ = 0)
        {
            base.Shot(bulletPool, effectsPool, bulletStats, bulletType, rotZ);
        }

        private void OnDisable() => Explode();

        private void Explode()
        {
            Effect effectInstance = _effectsPool.Get(_effect);
            effectInstance.transform.position = transform.position;
            effectInstance.Initialize(_effectsPool);
        }
    }
}