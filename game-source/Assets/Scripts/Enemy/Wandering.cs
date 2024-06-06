using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wandering : MonoBehaviour
{
    // The Wandering script makes the monsters move from side to side.
    public float range;
    public float movSpeed;
    private Rigidbody2D rb;
    private float minX;
    private float maxX;
    private int direction;

    // References to Sprite Renderers in order to flip them.
    public SpriteRenderer spriteRendererOutline;
    public SpriteRenderer spriteRendererFill;
    private Animator animator;
    private bool isMoving;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 position = transform.position;
        minX = position.x - range;
        maxX = position.x + range;
        StartCoroutine(ChillThenTurn(2, true));
        animator = GetComponent<Animator>();
    }

    void Turn(bool right)
    {
        if (right)
        {
            direction = 1;
            FlipSprites(true);
        }
        else
        {
            direction = -1;
            FlipSprites(false);
        }
    }

    void FlipSprites(bool dir)
    {
        spriteRendererOutline.flipX = dir; 
        spriteRendererFill.flipX = dir; 
    }

    // They always wait a bit before turning, hence this method
    IEnumerator ChillThenTurn(float numberOfSeconds, bool dir)
    {
        isMoving = false;
        yield return new WaitForSeconds(numberOfSeconds);
        Turn(dir);
        isMoving = true;
    }

    void Update()
    {
        if (isMoving)
        {
            animator.SetBool("IsMoving", true);
            rb.transform.Translate(Vector2.right * (movSpeed * Time.deltaTime * direction));
            Vector3 position = transform.position;
            if (position.x < minX)
            {
                StartCoroutine(ChillThenTurn(2, true));
            }

            if (position.x > maxX)
            {
                StartCoroutine(ChillThenTurn(2, false));
            }
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }
}