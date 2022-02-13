using UnityEngine;

namespace Core
{
    public class Input : MonoBehaviour
    {
        public Controls controls;

        private Vector2 _movementDirection;

        public Vector2 MovementDirection { get => _movementDirection; }

        private void Awake() => controls = new Controls();
        private void OnEnable() => controls.Enable();
        private void OnDisable() => controls.Disable();
        private void Update() => _movementDirection = controls.Player.Movement.ReadValue<Vector2>();
    }
}