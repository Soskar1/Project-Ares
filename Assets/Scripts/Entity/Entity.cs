using UnityEngine;

namespace Core.Entities
{
    [RequireComponent(typeof(Shooting))]
    public class Entity : MonoBehaviour
    {
        protected IMovement _movement;
        [SerializeField] protected Shooting _shooting;

        private void Awake() => _movement = GetComponent<IMovement>();
    }
}