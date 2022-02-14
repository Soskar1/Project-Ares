using UnityEngine;

namespace Core
{
    public class Input : MonoBehaviour
    {
        public Controls controls;

        private Vector2 _movementDirection;
        private float _mouseWheel;

        public Vector2 MovementDirection { get => _movementDirection; }
        public float MouseWheel { get => _mouseWheel; }

        private void Awake() => controls = new Controls();
        private void OnEnable() => controls.Enable();
        private void OnDisable() => controls.Disable();
        private void Update()
        {
            _movementDirection = controls.Player.Movement.ReadValue<Vector2>();
            _mouseWheel = controls.Player.WeaponSwitch.ReadValue<float>();
        }
    }
}