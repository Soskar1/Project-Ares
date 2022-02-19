using Core.Entities;
using Core.Weapons;
using UnityEngine;

namespace Core
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private BaseEnemy _enemy;
        [SerializeField] private BaseBullet _bullet;
        [SerializeField] private Spawner _spawner;

        public Player Player => _player;
        public BaseEnemy Enemy => _enemy;
        public BaseBullet Bullet => _bullet;
        public Spawner Spawner => _spawner;
    }
}