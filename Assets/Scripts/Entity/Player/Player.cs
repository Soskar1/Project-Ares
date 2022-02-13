using UnityEngine;

public class Player : Entity
{
    [SerializeField] private Input _input;
    [SerializeField] private PlayerShooting _shooting;

    private void Start()
    {
        _input.controls.Player.Shoot.performed += _shooting.TakeInput;
        _input.controls.Player.Shoot.canceled += _shooting.TakeInput;
    }

    private void OnDisable()
    {
        _input.controls.Player.Shoot.performed -= _shooting.TakeInput;
        _input.controls.Player.Shoot.canceled -= _shooting.TakeInput;
    }

    private void FixedUpdate()
    {
        if (_movement != null)
            _movement.Move(_input.MovementDirection);
    }
}
