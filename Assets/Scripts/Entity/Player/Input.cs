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

            _controls.Player.ChangeWeapon.performed += ChangeWeapon;
        }

        private void OnDisable()
        {
            _controls.Disable();

            _controls.Player.ChangeWeapon.performed -= ChangeWeapon;
        }

        private void Update() => _movementDirection = _controls.Player.Movement.ReadValue<Vector2>();

        private void ChangeWeapon(InputAction.CallbackContext ctx) => OnWeaponSwitch?.Invoke((int)ctx.ReadValue<float>());
    }
}