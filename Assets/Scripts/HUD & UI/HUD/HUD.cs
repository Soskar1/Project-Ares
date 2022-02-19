using Core.Entities;
using UnityEngine;

namespace Core.UI
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private PlayerHealthHUD _playerHealthHUD;

        public void Initialize(GameController controller) => _playerHealthHUD.Initialize(controller.Player.Health);
    }
}