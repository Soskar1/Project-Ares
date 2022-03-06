using UnityEngine;

namespace Core.Effects
{
    public class Explosion : Effect
    {
        [SerializeField] private float _lifeTime;

        private void OnEnable() => StartCoroutine(Timer.Start(_lifeTime, () => _pool.Release(this)));
    }
}