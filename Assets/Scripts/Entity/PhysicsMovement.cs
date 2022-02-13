using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PhysicsMovement : MonoBehaviour, IMovement
{
    [SerializeField] private Rigidbody2D _rb2d;
    [SerializeField] private float _speed;

    public void Move(Vector2 direction) => _rb2d.velocity = direction * _speed * Time.fixedDeltaTime;
}
