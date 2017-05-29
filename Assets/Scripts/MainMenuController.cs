using UnityEngine;

namespace Assets.Scripts
{
    public class MainMenuController : MonoBehaviour
    {
        public void StartGame()
        {
            Game.LoadScene(2);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}