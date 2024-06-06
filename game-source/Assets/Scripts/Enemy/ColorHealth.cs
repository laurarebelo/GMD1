using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorHealth : MonoBehaviour
{
    // init RGB bools: What colors will the enemy initialize as?
    public bool initR;
    public bool initG;
    public bool initB;

    // RGB vals: how much of each color does the monster contain
    // at any moment?
    public float Rval;
    public float Gval;
    public float Bval;
    
    // Sprite Renderer for monster
    private SpriteRenderer spriteRenderer;
    public float maxHealth;
    private float health;
    
    // What hit color deals damage on this enemy?
    private string hitColor;
    
    // Reference to the HealthBarFill of the enemy.
    // (To dynamically change its fill value/percentage)
    public Image healthBarFill;
    
    // Reference to the Fill of the enemy.
    // (To dynamically change its color)
    public GameObject fill;
    
    // Reference to Kill Count to increment when the enemy is killed.
    public KillCount killCount;

    void Awake()
    {
        spriteRenderer = fill.GetComponent<SpriteRenderer>();
        if (initR && initG && initB)
        {
            throw new ArgumentException("An enemy cannot be initialized with all the colors!!!!");
        }
        
        health = maxHealth;
        InitColor();
        if (killCount == null)
        {
            // Try to find any Kill Count in the scene.
            killCount = FindObjectOfType<KillCount>();
        }
    }

    void InitColor()
    {
        Color initialColor = Colorz.GetColor(initR, initG, initB);
        SetColor(initialColor);
    }

    public void SetColor(Color col)
    {
        spriteRenderer.color = col;
        healthBarFill.color = col;
        Rval = col.r;
        Gval = col.g;
        Bval = col.b;
        
        // This part below looks odd but it was necessary
        // for when spawning slimes dynamically.
        // Because their init RGB bools had to be set somehow.
        initR = Rval == 1;
        initG = Gval == 1;
        initB = Bval == 1;

        SetHitColor();
    }

    void SetHitColor()
    {
        hitColor = Colorz.GetOppositeColorStr(initR, initG, initB);
    }

    public void GetHit(string incomingHitCol, float damage)
    {
        // Only get damaged if the incoming hit is the right color!
        if (incomingHitCol == hitColor)
        {
            health -= damage;
            UpdateColorBasedOnHealth();
            UpdateHealthFill();
            CheckForDeath();
        }
    }

    private void UpdateHealthFill()
    {
        float pct = health / maxHealth;
        healthBarFill.fillAmount = pct;
    }

    private void UpdateColorBasedOnHealth()
    {
        float pct = (maxHealth - health) / maxHealth;
        if (Rval < 1)
        {
            Rval = pct;
        }

        if (Gval < 1)
        {
            Gval = pct;
        }

        if (Bval < 1)
        {
            Bval = pct;
        }
        UpdateSpriteColor();
    }

    void UpdateSpriteColor()
    {
        Color newCol = new Color(Rval, Gval, Bval);
        spriteRenderer.color = newCol;
    }

    void CheckForDeath()
    {
        if (health <= 0)
        {
            killCount.IncrementKillCount();
            Destroy(gameObject);
        }
    }
}