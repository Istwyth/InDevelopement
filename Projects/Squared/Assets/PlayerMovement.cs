using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    public int direction;

    public float moveSpeed;
    public float jumpForce;
    public Transform ceilingCheck;
    public Transform groundCheck;
    public LayerMask groundObjects;
    public float checkRadius;
    public int maxJumpCount;

    private Rigidbody2D rb;
    private Animator animator;
    public bool facingRight = true;
    private float moveDirection;
    private bool isJumping = false;
    private bool isGrounded;
    private int jumpCount;

    public bool isMoving = false;

   private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void start()
    {
        jumpCount = maxJumpCount;
        dashTime = startDashTime;
    }
    
    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        Animate();
        isMoving = GetVelocity() > 0;

        if(GetVelocity() > 0)
        {
            isMoving = true;
            animator.SetBool("isMoving", true);
        } else
        {
            isMoving = false;
            animator.SetBool("isMoving", false);
        }

        //animator.SetBool("isMoving", isMoving);
        if(direction ==0)
            {
                if(Input.GetKeyDown(KeyCode.LeftArrow)){
                    direction = 1;
                } else if (Input.GetKeyDown(KeyCode.RightArrow)){
                    direction = 2;
                 } else if (Input.GetKeyDown(KeyCode.UpArrow)){
                    direction = 3;
                } else if (Input.GetKeyDown(KeyCode.DownArrow)){
                    direction = 4;
                }            
            

            }
            else {
                if(dashTime <= 0){
                    direction = 0;
                    dashTime = startDashTime;
                    rb.velocity = Vector2.zero;
                } else {
                    dashTime -= Time.deltaTime;

                    if(direction == 1){
                        rb.velocity = Vector2.left * dashSpeed;
                    } else if(direction == 2){
                        rb.velocity = Vector2.right * dashSpeed;
                    }else if(direction == 3){
                        rb.velocity = Vector2.up * dashSpeed;
                    } else if(direction == 4){
                        rb.velocity = Vector2.down * dashSpeed;
                    }
            }
        }
    }



    private void FixedUpdate()
    {
       isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
       if (isGrounded)
       {
           jumpCount = maxJumpCount;
       }

        Move();

    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if (isJumping && jumpCount > 0)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            jumpCount--;
        }
        isJumping = false;
    }

    private void Animate()
    {
        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }
    }

    private void ProcessInputs()
    {
        moveDirection = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            isJumping = true;
        }
    }

    public void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f,180f, 0f);
    }

    public float GetVelocity()
    {
        return rb.velocity.magnitude;
    }


}
