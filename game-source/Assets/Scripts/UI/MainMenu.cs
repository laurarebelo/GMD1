using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("0-Cutscene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
