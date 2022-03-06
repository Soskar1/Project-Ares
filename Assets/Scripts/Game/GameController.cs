using Core.Entities;
using Core.Weapons;
using UnityEngine;

namespace Core
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Spawner _spawner;

        public Player Player => _player;
        public Spawner Spawner => _spawner;
    }
}