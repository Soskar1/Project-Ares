using UnityEngine;

public class Entity : MonoBehaviour
{
    protected IMovement _movement;

    private void Awake() => _movement = GetComponent<IMovement>();
}
