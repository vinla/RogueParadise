using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.ViewModels
{
    public class GameOverViewModel : UnityViewModel
    {
        public MvvmCommand Restart
        {
            get
            {
                return new MvvmCommand(o =>
                {
                    var currentScene = SceneManager.GetActiveScene();
                    Game.LoadScene(currentScene.buildIndex);                    
                });
            }
        }

        public MvvmCommand MainMenu
        {
            get
            {
                return new MvvmCommand(o =>
                {
                    Game.LoadScene(0);
                });
            }
        }

        public MvvmCommand Quit
        {
            get
            {
                return new MvvmCommand(o =>
                {
                    Game.Quit();
                });
            }
        }
    }
}
