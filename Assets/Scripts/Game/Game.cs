using UnityEngine;
using Core.UI;

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
        }

        private void Start()
        {
            _hud.Initialize(_controller);
        }
    }
}