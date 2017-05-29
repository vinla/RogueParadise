using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public static class Game
    {
        public static Int32 NextSceneIndex { get; set; }

        public static void LoadScene(Int32 sceneToLoad)
        {
            NextSceneIndex = sceneToLoad;
            SceneManager.LoadScene(1);
            Time.timeScale = 1f;
        }

        public static void GameOver()
        {
            Time.timeScale = 0f;
            UIManager.Current.PushView("GameOver");
        }

        public static void NextLevel()
        {
            LoadScene(NextSceneIndex+1);
        }

        public static void Quit()
        {
            //UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }
}
