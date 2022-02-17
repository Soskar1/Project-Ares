using Core.Weapons;
using UnityEngine;

namespace Core.Entities
{
    public class Shooting : MonoBehaviour
    {
        public Weapon weapon;
        private bool _timerStarted = false;

        private void Update()
        {
            if (_timerStarted == true)
                return;

            _timerStarted = true;
            StartCoroutine(Timer.Start(weapon.maxTime, () => { weapon.Fire(); _timerStarted = false; }));
        }

        private void OnDisable() => _timerStarted = false;
    }
}