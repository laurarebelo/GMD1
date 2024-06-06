using System;
using UnityEngine;

namespace Pickups
{
    // Oh my. I made a health pickup and ended up
    // not including it because I felt that
    // the levels were short enough that the
    // respawns were a good enough way to restore
    // health. But I guess... For a future version,
    // with longer levels, this would have been useful!
    public class HealthPickup : MonoBehaviour
    {
        public int healthAmount;
        private RespawnOffScreen respawn;

        private void Start()
        {
            respawn = GetComponent<RespawnOffScreen>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (respawn.active)
            {
                Health otherHealth = other.GetComponent<Health>();
                if (otherHealth != null)
                {
                    if (otherHealth.health < otherHealth.maxHealth)
                    {
                        otherHealth.Heal(healthAmount);
                        respawn.Active(false);
                    }
                }  
            }
        }
    }
}
