using UnityEngine;

namespace Core.Entities
{
    public class DeathZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Entity entity))
                Pool<Entity>.pool.Release(entity);
        }
    }
}