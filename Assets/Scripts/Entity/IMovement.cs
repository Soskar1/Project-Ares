using UnityEngine;

namespace Core.Entities
{
    public interface IMovement
    {
        float Speed { get; set; }
        void Move(Vector2 direction);
    }
}