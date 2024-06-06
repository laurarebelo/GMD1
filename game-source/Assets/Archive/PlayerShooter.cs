using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerShooter : MonoBehaviour
{
    private Transform bulletTransform;
    public GameObject bullet;
    private bool canFire;
    private float timer;
    public float timeBetweenFiring;
    public float bulletSpeed;
    public float bulletDamage;

    public bool infinitePaint;

    private bool shootingR;
    private bool shootingG;
    private bool shootingB;

    public float fuelSpendRate = 10;

    public float Rfuel = 100;
    public float Gfuel = 100;
    public float Bfuel = 100;

    private Animator playerAnimator;

    private bool isBlocked = false;
    
    // Start is called before the first frame update
    void Start()
    {
        bulletTransform = transform.Find("RotatePoint").Find("BulletTransform");
        canFire = true;
        playerAnimator = GetComponent<Animator>();
    }

    public void ToggleBlock(bool state)
    {
        isBlocked = state;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBlocked) return;
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        bool isFirePressed = CheckForColorInput();
        playerAnimator.SetBool("IsAttacking", isFirePressed);
        
        if (isFirePressed && canFire && IsThereFuel())
        {
            Shoot();
        }
    }

    bool IsThereFuel()
    {
        return (shootingR && Rfuel > 0) || (shootingG && Gfuel > 0) || (shootingB && Bfuel > 0);
    }

    void FixedUpdate()
    {
        SpendPaint();
    }

    void Shoot()
    {
        canFire = false;
        GameObject bulGo = Instantiate(bullet, bulletTransform.position, bulletTransform.rotation);
        Bullet bul = bulGo.GetComponent<Bullet>();
        Color fireColor = Colorz.GetColor(
            shootingR && Rfuel > 0,
            shootingG && Gfuel > 0, 
            shootingB && Bfuel > 0);
        bul.SetColor(fireColor);
        bul.SetSpeed(bulletSpeed);
        bul.SetDamage(bulletDamage);
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
        if (infinitePaint)
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

    private bool CheckForColorInput()
    {
        shootingR = Input.GetButton("FireR");
        shootingG = Input.GetButton("FireG");
        shootingB = Input.GetButton("FireB");

        return shootingR || shootingG || shootingB;
    }
}
