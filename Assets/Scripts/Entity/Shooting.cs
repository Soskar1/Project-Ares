using Core.Weapons;
using UnityEngine;

namespace Core.Entities
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField] private Weapon _initWeapon;
        private Weapon _currentWeapon;

        private BulletPool _bulletPool;
        private EffectsPool _effectsPool;

        private bool _timerStarted = false;

        private void Update()
        {
            if (_timerStarted == true)
                return;

            _timerStarted = true;
            StartCoroutine(Timer.Start(_currentWeapon.Delay, () => { _currentWeapon.Fire(); _timerStarted = false; }));
        }

        private void OnDisable() => _timerStarted = false;

        public void Initialize(BulletPool bulletPool, EffectsPool effectsPool)
        {
            _bulletPool = bulletPool;
            _effectsPool = effectsPool;
            TakeWeapon(_initWeapon);
        }

        public void TakeWeapon(Weapon newWeapon)
        {
            _currentWeapon = newWeapon;
            _currentWeapon.Initialize(_bulletPool, _effectsPool);
        }
    }
}