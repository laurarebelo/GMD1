using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // Class to be able to exit the game at the end of the game.
    private bool active = false;
    void Update()
    {
        if (active)
        {
            if (Input.GetButton("Submit") || Input.GetAxis("Submit")> 0.0f)
            {
                Application.Quit();
            } 
        }
    }

    public void Activate()
    {
        active = true;
    }
}
