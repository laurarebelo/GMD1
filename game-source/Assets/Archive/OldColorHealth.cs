using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldColorHealth : MonoBehaviour
{
    public bool initR;

    public bool initG;

    public bool initB;

    private float Rval;
    private float Gval;
    private float Bval;
    private SpriteRenderer spriteRenderer;
    public float maxHealth;
    private float health;
    public int gunStrength;
    private float colorValuePerHealthPoint;

    private bool shootingR;
    private bool shootingG;
    private bool shootingB;

    private string hitColor;

    public float fireRate;


    // Start is called before the first frame update
    void Start()
    {
        colorValuePerHealthPoint = 1f / maxHealth;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Color initialColor = InitColor(initR, initG, initB);
        spriteRenderer.color = initialColor;
        SetHitColor();
    }

    void SetHitColor()
    {
        string opCol = "";
        if (!initR)
        {
            opCol += "R";
        }

        if (!initG)
        {
            opCol += "G";
        }

        if (!initB)
        {
            opCol += "B";
        }
        hitColor = opCol;
    }

    Color InitColor(bool r, bool g, bool b)
    {
        if (r)
        {
            Rval = 1;
        }

        if (g)
        {
            Gval = 1;
        }

        if (b)
        {
            Bval = 1;
        }

        return new Color(Rval, Gval, Bval);
    }

    public void GetHit(string incomingHitCol, float damage)
    {
        if (incomingHitCol == hitColor)
        {
            health -= damage;
            UpdateColorBasedOnHealth();
        }
    }

    private void UpdateColorBasedOnHealth()
    {
        float pct = health / maxHealth;
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

    private void IncrementColorVal(char color)
    {
        string col = color.ToString().ToLower();
        if (!(col == "r" || col == "g" || col == "b"))
        {
            throw new ArgumentException("You have provided an invalid color ma'am.");
        }

        Debug.Log("Hitting with: " + col);

        switch (col)
        {
            case "r":
                if (Rval >= 1) return;
                Debug.Log("Old Rval: " + Rval);
                Rval += GunDamage() * fireRate;
                Debug.Log("New Rval: " + Rval);
                break;
            case "g":
                if (Gval >= 1) return;
                Gval += GunDamage() * fireRate;
                break;
            case "b":
                if (Bval >= 1) return;
                Bval += GunDamage() * fireRate;
                break;
        }

        UpdateSpriteColor();
    }

    float GunDamage()
    {
        return colorValuePerHealthPoint * gunStrength;
    }

    void UpdateSpriteColor()
    {
        Color newCol = new Color(Rval, Gval, Bval);
        spriteRenderer.color = newCol;
    }

    private void ShootColorContinuously(bool r, bool g, bool b)
    {
        if (r)
        {
            IncrementColorVal('r');
        }

        if (g)
        {
            IncrementColorVal('g');
        }

        if (b)
        {
            IncrementColorVal('b');
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckForColorPress();
        CheckForDeath();
    }

    void CheckForDeath()
    {
        if (Rval >= 1 && Gval >= 1 && Bval >= 1)
        {
            Destroy(gameObject);
        }
    }

    void CheckForColorPress()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            shootingR = true;
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            shootingR = false;
        }
        
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            shootingG = true;
        }

        if (Input.GetKeyUp(KeyCode.G))
        {
            shootingG = false;
        }
        
        
        if (Input.GetKeyDown(KeyCode.B))
        {
            shootingB = true;
        }

        if (Input.GetKeyUp(KeyCode.B))
        {
            shootingB = false;
        }
    }

    void FixedUpdate()
    {
        ShootColorContinuously(shootingR, shootingG, shootingB);
    }
}