using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ExternalTriggers : MonoBehaviour
{
    // External triggers handles triggering
    // anything external to the dialogue
    // that depends on the dialogue's timing,
    // such as playing a Timeline on exit
    // or spawning slimes after the dialogue finishes.
    public PlayableDirector exitScene;
    public SlimeSpawner slimeSpawner;

    public void HandleEndOfDialogue(bool isFinal)
    {
        if (exitScene != null && isFinal)
        {
            exitScene.Play();
        }

        if (slimeSpawner != null)
        {
            slimeSpawner.SpawnNext();
        }
    }
}
