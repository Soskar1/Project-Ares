using UnityEngine;

namespace Core
{
    public class Game : MonoBehaviour
    {
        private void Awake()
        {
            Application.targetFrameRate = 60;
            Screen.SetResolution(1920, 1080, true);

            //Invisible Wall & Enemy
            Physics2D.IgnoreLayerCollision(6,7);
        }
    }
}