using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootSpray : MonoBehaviour
{
    // Spray Mechanics
    private Transform sprayTransform;
    public GameObject sprayPrefab;
    public float sprayDamage;
    private Spray spray;
    
    private bool isBlocked = false;
    private bool firing = false;
    
    private PlayerAudioManager audioSrc;

    // Fuel Mechanics
    private bool shootingR;
    private bool shootingG;
    private bool shootingB;
    
    public bool infinitePaint;
    public float fuelSpendRate = 10;
    
    public float Rfuel = 100;
    public float Gfuel = 100;
    public float Bfuel = 100;
    
    // Animation
    private Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        sprayTransform = transform.Find("RotatePoint").Find("BulletTransform");
        animator = GetComponent<Animator>();
        audioSrc = GetComponent<PlayerAudioManager>();
    }
    
    public void ToggleBlock(bool state)
    {
        isBlocked = state;
        if (state)
        {
            StopShooting();
        }
    }
    
    // Function to check if the Player is lacking
    // any of the specified Paint colors
    public bool IsLackingAny(bool r, bool g, bool b)
    {
        if (r)
        {
            if (Rfuel < 100)
            {
                return true;
            }
        }

        if (g)
        {
            if (Gfuel < 100)
            {
                return true;
            }
        }

        if (b)
        {
            if (Bfuel < 100)
            {
                return true;
            }
        }

        return false;
    }
    
    void Update()
    {
        if (isBlocked) return;
        
        bool isFirePressed = CheckForColorInput();
        animator.SetBool("IsAttacking", isFirePressed);
        
        // First frame of spraying
        if (!firing && isFirePressed && IsThereFuel())
        {
            StartShooting();
        }

        // Constantly checking if the spray color changes
        if (firing && isFirePressed && IsThereFuel())
        {
            ChangeColor();
        }

        // If the trigger is released or the Player runs out of fuel,
        // stop firing
        if (firing && (!isFirePressed || !IsThereFuel()))
        {
            StopShooting();
        }
    }

    // Is there fuel for any of the colors the Player is trying to fire?
    bool IsThereFuel()
    {
        return (shootingR && Rfuel > 0) || (shootingG && Gfuel > 0) || (shootingB && Bfuel > 0);
    }
    
    // Continuously try to spend paint.
    // The SpendPaint() function will handle whether
    // or not paint should actually be spent.
    void FixedUpdate()
    {
        SpendPaint();
    }

    void StartShooting()
    {
        audioSrc.StartGraffiti();
        firing = true;
        GameObject sprayGo = Instantiate(sprayPrefab, sprayTransform.position, sprayTransform.rotation);
        // Make the Spray a child of the SprayTransform so that it
        // "follows" the Player around.
        sprayGo.transform.parent = sprayTransform;
        spray = sprayGo.GetComponent<Spray>();
        Color fireColor = Colorz.GetColor(
            shootingR && Rfuel > 0,
            shootingG && Gfuel > 0, 
            shootingB && Bfuel > 0);
        spray.SetColor(fireColor);
        spray.SetDamage(sprayDamage);
    }

    void ChangeColor()
    {
        Color fireColor = Colorz.GetColor(
            shootingR && Rfuel > 0,
            shootingG && Gfuel > 0, 
            shootingB && Bfuel > 0);
        spray.SetColor(fireColor);
    }

    public void StopShooting()
    {
        if (firing)
        {
            firing = false;
            audioSrc.StopGraffiti();
            Destroy(spray.gameObject); 
            animator.SetBool("IsAttacking", false);
        }
    }
    
    public void Fill(bool r, bool g, bool b)
    {
        if (r)
        {
            Rfuel = 100;
        }

        if (g)
        {
            Gfuel = 100;
        }

        if (b)
        {
            Bfuel = 100;
        }
    }
    
    
    void SpendPaint()
    {
        if (infinitePaint || isBlocked)
        {
            return;
        }
        if (shootingR)
        {
            if (Rfuel > 0)
            {
                Rfuel -= fuelSpendRate * Time.deltaTime;
            }
        }

        if (shootingG)
        {
            if (Gfuel > 0)
            {
                Gfuel -= fuelSpendRate * Time.deltaTime;
            }
        }
        
        if (shootingB)
        {
            if (Bfuel > 0)
            {
                Bfuel -= fuelSpendRate * Time.deltaTime;
            }
        }
    }

    private bool CheckForColorInput()
    {
        shootingR = Input.GetButton("FireR");
        shootingG = Input.GetButton("FireG");
        shootingB = Input.GetButton("FireB");
        return shootingR || shootingG || shootingB;
    }
    
}
