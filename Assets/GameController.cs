using Core.Entities;
using UnityEngine;

namespace Core
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Player _player;

        public Player Player => _player;
    }
}