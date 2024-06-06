using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject controlsMenu;
    public PlayerBlocker playerBlocker;

    private bool paused;
    private bool blocked;

    private bool inControls;
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (blocked) return;
        if (Input.GetButtonDown("Submit"))
        {
            if (!paused)
            {
                Pause();
            }
        }

        if (inControls)
        {
            if (Input.GetButtonDown("Submit"))
            {
                LeaveControls();
            }  
        }
    }

    // Function to Block the Pause menu, for example,
    // so the player isn't able to Pause during a dialogue.
    public void TogglePauseBlock(bool state)
    {
        blocked = state;
    }

    public void Pause()
    {
        if (!paused)
        {
            Debug.Log("Paused");
            paused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            playerBlocker.ToggleBlock(true);
        }
    }
    
    // Function to block the Pause button for a short while
    // Because some inputs are used for two things
    // which sometimes caused conflicts, sooo... This fixed it!
    public IEnumerator BlockPauseForSeconds(float seconds)
    {
        blocked = true;
        yield return new WaitForSecondsRealtime(seconds);
        blocked = false;
    }

    public void Resume()
    {
        if (paused)
        {
            Debug.Log("Resumed");
            paused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            playerBlocker.ToggleBlock(false);
            StartCoroutine(BlockPauseForSeconds(0.1f));
        }
    }

    // Entering the Controls menu
    public void EnterControls()
    {
        inControls = true;
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(true);
        StartCoroutine(BlockPauseForSeconds(0.1f));
    }

    // Leaving the Controls menu
    public void LeaveControls()
    {
        inControls = false;
        controlsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
