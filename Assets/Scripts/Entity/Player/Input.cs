using UnityEngine;
using UnityEngine.InputSystem;
using System;

namespace Core
{
    public class Input : MonoBehaviour
    {
        private Controls _controls;
        public Controls Controls => _controls;

        private Vector2 _movementDirection;
        public Vector2 MovementDirection { get => _movementDirection; }

        public Action<int> OnWeaponSwitch;

        private void Awake() => _controls = new Controls();

        private void OnEnable()
        {
            _controls.Enable();

            _controls.Player.StraightLineGun.performed += FirstWeapon;
            _controls.Player.Shotgun.performed += SecondWeapon;
            _controls.Player.RocketLauncher.performed += ThirdWeapon;
        }

        private void OnDisable()
        {
            _controls.Disable();

            _controls.Player.StraightLineGun.performed -= FirstWeapon;
            _controls.Player.Shotgun.performed -= SecondWeapon;
            _controls.Player.RocketLauncher.performed -= ThirdWeapon;
        }

        private void Update() => _movementDirection = _controls.Player.Movement.ReadValue<Vector2>();

        private void FirstWeapon(InputAction.CallbackContext obj) => OnWeaponSwitch?.Invoke(0);
        private void SecondWeapon(InputAction.CallbackContext obj) => OnWeaponSwitch?.Invoke(1);
        private void ThirdWeapon(InputAction.CallbackContext obj) => OnWeaponSwitch?.Invoke(2);

    }
}