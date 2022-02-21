using UnityEngine;

namespace Core.Entities
{
    [RequireComponent(typeof(Input))]
    public class Player : Entity
    {
        [SerializeField] private Input _input;

        private void FixedUpdate()
        {
            if (Movement != null)
                Movement.Move(_input.MovementDirection);
        }
    }
}