using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintPickup : MonoBehaviour
{
    // Paint pickup to recharge your paint levels!
    // Very important throughout the game.
    // They usually respawn off screen.
    // They make a little sound when collected.
    
    // RGB bools to set the color of the Paint Pickup.
    public bool r;
    public bool g;
    public bool b;
    
    // Reference to the GameObject of the fill
    // so that its color can be dynamically set.
    public GameObject fill;
    
    private RespawnOffScreen respawn;
    private AudioSource audioSrc;

    void Start()
    {
        Color initialColor = Colorz.GetColor(r, g, b);
        SpriteRenderer sr = fill.GetComponent<SpriteRenderer>();
        sr.color = initialColor;
        respawn = GetComponent<RespawnOffScreen>();
        audioSrc = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (respawn.active)
        {
            PlayerShootSpray otherFuel = other.GetComponent<PlayerShootSpray>();
            if (otherFuel != null)
            {
                // If the Player is lacking any of the paint that is
                // included in this pickup, he will collect the pickup
                // and restore that paint.
                if (otherFuel.IsLackingAny(r, g, b))
                {
                    audioSrc.Play();
                    otherFuel.Fill(r,g,b);
                    respawn.Active(false);
                }
            } 
        }
        
    }
}
