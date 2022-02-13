using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : Shooting
{
    [SerializeField] private float _maxTime;

    private bool _isShooting = false;
    private bool _timerStarted = false;

    private void Update()
    {
        if (_isShooting == false)
            return;

        if (_timerStarted == true)
            return;

        _timerStarted = true;
        StartCoroutine(Timer.Start(_maxTime, () => { Shoot(); _timerStarted = false; }));
    }

    public void TakeInput(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            _isShooting = true;
        else if (ctx.canceled)
            _isShooting = false;
    }
}
