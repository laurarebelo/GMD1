using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // Script that handles the health of the Player.
    
    // Health-related properties
    public int maxHealth;
    public float health;
    public Image healthBarFill;
    public bool infiniteHealth;
    
    // Damage-receiving-related properties
    public float hitTimeout;
    private bool canTakeDmg;
    private float timer;
    private Vector3 respawnPosition;
    private PlayerAudioManager audioSrc;

    // UI-related properties
    private bool spriteFlashing;
    private bool spriteTimeout;
    private bool spriteTimer;
    private SpriteRenderer spriteRenderer;

    
    void Start()
    {
        canTakeDmg = true;
        health = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        Vector3 ip = transform.position;
        respawnPosition = new Vector3(ip.x, ip.y, ip.z);
        audioSrc = GetComponent<PlayerAudioManager>();
    }

    void Update()
    {
        if (infiniteHealth) return;
        if (!canTakeDmg)
        {
            timer += Time.deltaTime;
            if (timer > hitTimeout)
            {
                canTakeDmg = true;
                timer = 0;
            }
        }
    }

    public void Heal(int howMuch)
    {
        health += howMuch;

        if (health >= maxHealth)
        {
            health = maxHealth;
        }
        UpdateHealthFill();
    }

    public void GetHit(int damage, Color color)
    {
        if (canTakeDmg)
        {
            audioSrc.TakeDamage();
            health -= damage;
            if (health < 0)
            {
                health = 0;
            }
            CheckForDeath();
            UpdateHealthFill();
            canTakeDmg = false;
            spriteRenderer.color = color;
            StartCoroutine(GoBackToWhite());
        }
    }

    private IEnumerator GoBackToWhite()
    {
        yield return new WaitForSeconds(hitTimeout);
        spriteRenderer.color = Color.white;
    }

    private void UpdateHealthFill()
    {
        float pct = health / maxHealth;
        healthBarFill.fillAmount = pct;
    }

    void CheckForDeath()
    {
        if (health <= 0)
        {
            gameObject.transform.position = respawnPosition;
            Heal(maxHealth);
        }
    }
}