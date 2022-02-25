using UnityEngine;
using Core.UI;
using Core.Weapons;
using Core.Entities;

namespace Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private GameController _controller;
        [SerializeField] private HUD _hud;
        [SerializeField] private Spawner _spawner;
        [SerializeField] private DeathZone _deathZone;

        private Pool<BaseEnemy> _enemyPool;
        //private Pool<BaseBullet> _bulletPool;
        private BulletPool _bulletPool;

        private void Awake()
        {
            Application.targetFrameRate = 60;
            Screen.SetResolution(1920, 1080, true);

            //Invisible Wall & Enemy
            Physics2D.IgnoreLayerCollision(6,7);

            _enemyPool = new Pool<BaseEnemy>();
            //bulletPool = new Pool<BaseBullet>();
        }

        private void Start()
        {
            _hud.Initialize(_controller);

            _enemyPool.Initialize(_controller.Enemy, true, 25, 50);
            //_bulletPool.Initialize(_controller.Bullet, true, 100, 150);
            _bulletPool = new BulletPool();

            //_spawner.Initialize(_enemyPool, _bulletPool);
            _deathZone.Initialize(_enemyPool);

            _controller.Player.Initialize(_bulletPool);

            _controller.Player.gameObject.SetActive(true);
            //_controller.Spawner.gameObject.SetActive(true);
        }
    }
}