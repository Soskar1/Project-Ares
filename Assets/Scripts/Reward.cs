using UnityEngine;

namespace Core.Collectibles
{
    public class Reward : MonoBehaviour
    {
        [SerializeField] private Collectible _collectible;

        private void OnDisable() => SpawnReward();
        private void SpawnReward() => Instantiate(_collectible, transform.position, Quaternion.identity);
    }
}