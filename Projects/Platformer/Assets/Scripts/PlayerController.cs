using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    public Transform ceilingCheck;
    public Transform groundCheck;
    public LayerMask groundObjects;
    public float checkRadius;
    
    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;
    private bool isJumping = false;
    private bool isGrounded;

    //Dash Variables
    private bool isDashing;
    public float dashTime;
    public float dashSpeed;
    public float distanceBetweenImages;
    public float dashCoolDown;
    private float dashTimeLeft;
    private float lastImageXpos;
    private float lastDash = -100f;


    // Awake is called before the Start method
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // will look for a component on this GameObject

    }

     // Update is called once per frame
    void Update()
    {
            //Check if Player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);

        //Get player inputs
        ProcessInputs();

        //Animate
        Animate();

        CheckDash();
        
    }

    private void OnTriggerEnter2D(Collider2D star) // Handles the collisions between Player and Star
    {
        if(star.gameObject.CompareTag("Star"))
        {
            Destroy(star.gameObject);
        }
    }

    private void FixedUpdate()
    {
        //Move
        Move();
    }

    private void ProcessInputs()
    {
        moveDirection = Input.GetAxis("Horizontal");// Scale being left -1, right 1
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
        if(Input.GetButtonDown("Dash"))
        {
            if(Time.time >= (lastDash + dashCoolDown))
            
            AttemptToDash();
            
            
        }
        
    }

    private void AttemptToDash()
    {
        isDashing = true;
        dashTimeLeft = dashTime;
        lastDash = Time.time;

        PlayerAfterImagePool.Instance.GetFromPool();
        lastImageXpos = transform.position.x;

    }

    private void CheckDash()
    {
        if(isDashing) // Checks if the player should be dashing
        {
            if(dashTimeLeft > 0)
            {
                
                rb.velocity = new Vector2(dashSpeed * moveDirection, rb.velocity.y);
                dashTimeLeft -= Time.deltaTime;

                if(Mathf.Abs(transform.position.x - lastImageXpos) > distanceBetweenImages)
                {
                    PlayerAfterImagePool.Instance.GetFromPool();
                    lastImageXpos = transform.position.x;
                }
            }
            
            if(dashTimeLeft <= 0)
            {
                isDashing = false;
                
            }

        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if(isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        } isJumping = false;
    }

    private void Animate()
    {
        if(moveDirection > 0 && !facingRight)
        {
            FlipCharacter();

        } else if(moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight; //Inverse bool
        transform.Rotate(0f, 180f, 0f);

    }
}
