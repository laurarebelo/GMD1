using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spray : MonoBehaviour
{
    public SpriteRenderer fillSr;
    private string sprayColor;
    private float damage;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out ColorHealth colorHealth))
        {
            colorHealth.GetHit(sprayColor, damage * Time.deltaTime);
        }
    }
    
    public void SetDamage(float dmg)
    {
        damage = dmg;
    }
    
    public void SetColor(Color color)
    {
        fillSr.color = color;
        sprayColor = Colorz.GetColorStr(color);
    }
}
