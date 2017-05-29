using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class SceneLoader : MonoBehaviour
    {
        public void Start()
        {
            StartCoroutine("LoadScene");
        }

        private IEnumerator LoadScene()
        {
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(Game.NextSceneIndex);
        }
    }
}
