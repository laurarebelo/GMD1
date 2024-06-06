using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : MonoBehaviour
{
    // PlayerPlatformerController handles everything
    // related to moving the player around.
    
    // Player movement parameters
    public float movSpeed;
    public float jumpHeight;
    public LevelBounds levelBounds;
    private Rigidbody2D rb;

    // Player animation parameters
    private Animator animator;
    private Transform rotPoint;
    private SpriteRenderer spriteRenderer;
    
    // Player state
    private bool isBlocked = false;
    private bool isWalking = false;
    
    // Audio
    private PlayerAudioManager audioSrc;

    void Start()
    {
        rotPoint = transform.Find("RotatePoint");
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audioSrc = GetComponent<PlayerAudioManager>();
    }

    public void ToggleBlock(bool state)
    {
        isBlocked = state;
        animator.SetBool("IsWalking", false);
        audioSrc.StopWalking();
        isWalking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBlocked) return;
        float x = Input.GetAxisRaw("Horizontal");
        
        // if the position.x is smaller or equal to the minX and the xInput is smaller than 0, dont move
        // if the position.x is bigger or equal to the maxX and the xInput is bigger than 0, dont move

        if (!(transform.position.x < levelBounds.minX && x < 0) && !(transform.position.x > levelBounds.maxX && x > 0))
        {
            rb.transform.Translate(Vector2.right * (x * movSpeed * Time.deltaTime));
        }
        
        float rotZ = Mathf.Atan2(0, x) * Mathf.Rad2Deg;
        Vector2 vel = rb.velocity;

        if (x != 0)
        {
            rotPoint.rotation = Quaternion.Euler(0, 0, rotZ);
            spriteRenderer.flipX = x < 0f;
            animator.SetBool("IsWalking", true);
            if (!isWalking && vel.y == 0)
            {
                audioSrc.StartWalking();
            }
            isWalking = true;
        }
        else
        {
            animator.SetBool("IsWalking", false);
            audioSrc.StopWalking();
            isWalking = false;
        }
        
        if (Input.GetAxisRaw("Vertical") == 1 || Input.GetButton("Jump"))
        {
            Jump();
        }
        
        animator.SetBool("IsJumping", vel.y != 0);
    }
    
    void Jump()
    {
        if (isBlocked) return;
        Vector2 vel = rb.velocity;
        if (vel.y == 0)
        {
            audioSrc.Jump();
            audioSrc.StopWalking();
            isWalking = false;
            rb.velocity = new Vector2(0, jumpHeight);
        }
    }
}
