using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    // This class is for Game Objects that inflict damage
    // on the player.
    
    // Value of damage dealt.
    [SerializeField] public int damageDealt;
    // Color of the hit dealt.
    // This is used to color a player when he gets damaged.
    private Color hitCol;

    private void Start()
    {
        ColorHealth ch = GetComponent<ColorHealth>();
        if (ch != null)
        {
            hitCol = Colorz.GetColor(ch.initR, ch.initG, ch.initB);
        }
        else
        {
            // The default color of a damage dealing GameObject,
            // if he doesn't have a ColorHealth component,
            // is CYAN, because the only GameObject without
            // a ColorHealth component that deals damage
            // is the sewer water in the third level ahahahah.
            hitCol = Colorz.GetColor(false, true, true);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        Health otherHealth = other.gameObject.GetComponent<Health>();
        
        // In other words, if the object on collision is a Player
        if (otherHealth != null)
        {
            // Hurt the Player with the color of this Game Object
            otherHealth.GetHit(damageDealt, hitCol);
        }
    }
}
