using UnityEngine;
using Core.UI;
using Core.Entities;

namespace Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private GameController _controller;
        [SerializeField] private HUD _hud;
        [SerializeField] private Spawner _spawner;
        [SerializeField] private DeathZone _deathZone;

        private EnemyPool _enemyPool;
        private BulletPool _bulletPool;
        private EffectsPool _effectsPool;

        //����� �������!
        [SerializeField] private bool _activateSpawner = true;

        private void Awake()
        {
            Application.targetFrameRate = 60;
            Screen.SetResolution(1920, 1080, true);
        }

        private void Start()
        {
            _hud.Initialize(_controller);

            _bulletPool = new BulletPool();
            _enemyPool = new EnemyPool();
            _effectsPool = new EffectsPool();

            _spawner.Initialize(_enemyPool, _bulletPool, _effectsPool);
            _deathZone.Initialize(_enemyPool);

            _controller.Player.Initialize(_bulletPool, _effectsPool);

            _controller.Player.gameObject.SetActive(true);

            if(_activateSpawner)
                _controller.Spawner.gameObject.SetActive(true);
        }
    }
}