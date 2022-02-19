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

        private void Awake()
        {
            Application.targetFrameRate = 60;
            Screen.SetResolution(1920, 1080, true);

            //Invisible Wall & Enemy
            Physics2D.IgnoreLayerCollision(6,7);

            Pool<BaseBullet>.Create(_controller.Bullet, true, 100, 150);
            Pool<BaseEnemy>.Create(_controller.Enemy, true, 25, 50);
        }

        private void Start()
        {
            _hud.Initialize(_controller);
            _controller.Player.gameObject.SetActive(true);
            _controller.Spawner.gameObject.SetActive(true);
        }
    }
}