using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlocker : MonoBehaviour
{
    // The PlayerBlocker is a class that handles
    // blocking the player's movement & attack,
    // for example, during the Pause menu or
    // during a Dialogue.
    
    // Maybe the same could have been achieved with Time.timescale = 0!
    // I only learned about that later though...
    private PlayerShootSpray shooter;
    private PlayerPlatformerController controller;
    void Start()
    {
        shooter = gameObject.GetComponent<PlayerShootSpray>();
        controller = gameObject.GetComponent<PlayerPlatformerController>();
    }

    public void ToggleBlock(bool state)
    {
        shooter.ToggleBlock(state);
        controller.ToggleBlock(state);
    }
}
