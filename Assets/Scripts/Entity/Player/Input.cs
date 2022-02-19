using UnityEngine;

namespace Core
{
    public class Input : MonoBehaviour
    {
        private Controls _controls;
        public Controls Controls => _controls;

        private Vector2 _movementDirection;
        public Vector2 MovementDirection { get => _movementDirection; }

        private void Awake() => _controls = new Controls();
        private void OnEnable() => _controls.Enable();
        private void OnDisable() => _controls.Disable();
        private void Update() => _movementDirection = _controls.Player.Movement.ReadValue<Vector2>();
    }
}