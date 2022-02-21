using Core.Weapons;
using UnityEngine;

namespace Core.Entities
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon;
        [SerializeField] private float _delay;
        private bool _timerStarted = false;

        private void Update()
        {
            if (_timerStarted == true)
                return;

            _timerStarted = true;
            StartCoroutine(Timer.Start(_delay, () => { _weapon.Fire(); _timerStarted = false; }));
        }

        private void OnDisable() => _timerStarted = false;

        public void Initialize(Pool<BaseBullet> bulletPool) => _weapon.Initialize(bulletPool);

        public void TakeWeapon(Weapon newWeapon) => _weapon = newWeapon;
    }
}