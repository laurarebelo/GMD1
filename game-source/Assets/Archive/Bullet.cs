using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private float speed;
    private string bulletColor;
    private float damage;
    private Camera mainCamera;
    private Vector2 widthThreshold;
    private Vector2 heightThreshold;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        mainCamera = Camera.main;
        widthThreshold = new Vector2(Screen.width * -0.04f, Screen.width * 1.04f);
        heightThreshold = new Vector2(Screen.height * -0.04f, Screen.height * 1.04f);
    }

    void Start()
    {
        Vector3 direction = transform.right;
        rb.velocity = new Vector2(direction.x, direction.y) * speed;
    }

    void Update()
    {
        Vector2 screenPosition = mainCamera.WorldToScreenPoint(transform.position);
        if (screenPosition.x < widthThreshold.x || screenPosition.x > widthThreshold.y ||
            screenPosition.y < heightThreshold.x || screenPosition.y > heightThreshold.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out ColorHealth colorHealth))
        {
            colorHealth.GetHit(bulletColor, damage);
        }

        if (!(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("Pickup")))
        {
            Destroy(gameObject);
        }
    }

    public void SetDamage(float dmg)
    {
        damage = dmg;
    }

    public void SetSpeed(float spd)
    {
        speed = spd;
    }

    public void SetColor(Color color)
    {
        sr.color = color;
        bulletColor = Colorz.GetColorStr(color);
    }
}