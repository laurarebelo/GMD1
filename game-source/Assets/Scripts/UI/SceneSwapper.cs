using UnityEngine;
using UnityEngine.SceneManagement;
    public class SceneSwapper : MonoBehaviour
    {
        public string sceneName;

        public void LoadScene()
        {
            SceneManager.LoadScene(sceneName);
        }
    }
