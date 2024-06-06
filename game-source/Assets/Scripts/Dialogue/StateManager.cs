using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    // State Manager serves to support the Dialogue Manager
    // by blocking other actions such as controlling
    // the player or pausing the game.
    public PlayerBlocker playerBlocker;
    public PauseMenu pauseController;

    public void TogglePlayerBlock(bool state)
    {
        if (playerBlocker != null)
        {
            playerBlocker.ToggleBlock(state);
        }
    }

    public void TogglePauseMenuBlock(bool state)
    {
        if (pauseController != null)
        {
            pauseController.TogglePauseBlock(state);
        }
    }

    public void BlockPauseMenuBriefly()
    {
        if (pauseController != null)
        {
            StartCoroutine(pauseController.BlockPauseForSeconds(0.1f));
        }
    }
}
