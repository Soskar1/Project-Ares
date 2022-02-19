using UnityEngine;

namespace Core.Entities
{
    public class DeathZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out BaseEnemy entity))
                Pool<BaseEnemy>.pool.Release(entity);
        }
    }
}