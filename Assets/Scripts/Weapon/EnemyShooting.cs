using UnityEngine;

public class EnemyShooting : Shooting
{
    [SerializeField] private float _maxTime;
    private bool _timerStarted = false;

    private void Update()
    {
        if (_timerStarted == true)
            return;

        _timerStarted = true;
        StartCoroutine(Timer.Start(_maxTime, () => { Shoot(); _timerStarted = false; }));
    }
}
