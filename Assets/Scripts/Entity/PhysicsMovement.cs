using UnityEngine;

namespace Core.Entities
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PhysicsMovement : MonoBehaviour, IMovement
    {
        [SerializeField] private Rigidbody2D _rb2d;
        [SerializeField] private float _speed;

        public float Speed { get => _speed; set => _speed = value; }

        public void Move(Vector2 direction) => _rb2d.velocity = direction * _speed * Time.fixedDeltaTime;
    }
}