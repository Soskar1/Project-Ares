using UnityEngine;
using TMPro;

namespace Core.Entities
{
    [RequireComponent(typeof(Input))]
    public class Player : Entity
    {
        [SerializeField] private Input _input;

        private void OnEnable()
        {
            //_health.OnChangeHealth +=
            //_health.OnDeath += 
        }

        private void OnDisable()
        {
            //_health.OnChangeHealth -=
            //_health.OnDeath -= 
        }

        private void FixedUpdate()
        {
            if (_movement != null)
                _movement.Move(_input.MovementDirection);
        }
    }
}