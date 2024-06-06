using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    // Class that handles the audio emitting of the player
    public AudioSource FootstepsSrc;
    public AudioSource GraffitiSrc;
    public AudioSource JumpSrc;
    public AudioSource DamageSrc;

    public void StartWalking()
    {
        // Slight delay, sounds better this way
        FootstepsSrc.time = 0.05f;
        FootstepsSrc.Play();
    }

    public void StopWalking()
    {
        FootstepsSrc.Stop();
    }

    public void StartGraffiti()
    {
        GraffitiSrc.Play();
    }

    public void StopGraffiti()
    {
        GraffitiSrc.Stop();
    }

    public void Jump()
    {
        JumpSrc.time = 0.1f;
        JumpSrc.Play();
    }

    public void TakeDamage()
    {
        DamageSrc.Play();
    }
}
