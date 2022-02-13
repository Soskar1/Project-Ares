using UnityEngine;

[RequireComponent(typeof(Input))]
public class Player : Entity
{
    [SerializeField] private Input _input;

    private void FixedUpdate()
    {
        if (_movement != null)
            _movement.Move(_input.MovementDirection);
    }
}
