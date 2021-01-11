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
    public float checkWidth;
    public float checkHeight;

    private Vector2 checkOffsetDownLeft;
    private Vector2 checkOffsetUpRight;
    
    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;
    private bool isJumping = false;
    [SerializeField] private bool isGrounded;

    //Dash Variables
    private bool isDashing;
    public float dashTime;
    public float dashSpeed;
    public float distanceBetweenImages;
    public float dashCoolDown;
    private float dashTimeLeft;
    private Vector2 lastImagePos;
    private float lastDash = -100f;

    private SpriteRenderer spriteRenderer;


    // Awake is called before the Start method
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // will look for a component on this GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();

        checkOffsetUpRight = new Vector2(+(checkWidth / 2), +(checkHeight / 2));
        checkOffsetDownLeft = new Vector2(-(checkWidth / 2), - (checkHeight / 2));

    }

     // Update is called once per frame
    void Update()
    {
            //Check if Player is grounded
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkHeight, groundObjects);
        isGrounded = Physics2D.OverlapArea(((Vector2) groundCheck.position)+ checkOffsetUpRight, ((Vector2)groundCheck.position) + checkOffsetDownLeft, groundObjects);

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
            {
                AttemptToDash();
            }        
        }
        
    }

    private void CreateAfterImage()
    {
        GameObject afterImage = PlayerAfterImagePool.Instance.GetFromPool();
        afterImage.GetComponent<PlayerAfterImageSprite>().SetParameters(spriteRenderer.sprite, transform.position, transform.rotation);
    }

    private void AttemptToDash()
    {
        isDashing = true;
        dashTimeLeft = dashTime;
        lastDash = Time.time;

        CreateAfterImage();
        lastImagePos = transform.position;

        rb.velocity = new Vector2(rb.velocity.x * dashSpeed, rb.velocity.y * dashSpeed);

    }

    private void CheckDash()
    {
        if(isDashing) // Checks if the player should be dashing
        {
            if(dashTimeLeft > 0)
            {
                
                //rb.velocity = new Vector2(dashSpeed * moveDirection, rb.velocity.y);
                
                dashTimeLeft -= Time.deltaTime;

                if(Mathf.Abs(((Vector2)((Vector2)transform.position) - lastImagePos).magnitude) > distanceBetweenImages)
                {
                    CreateAfterImage();
                    lastImagePos = transform.position;
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
        float dashMultiplier = 1f;
        if (isDashing)
        {
            dashMultiplier *= dashSpeed;
        }

        rb.velocity = new Vector2(moveDirection * moveSpeed * dashMultiplier, rb.velocity.y);
        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce * dashMultiplier), ForceMode2D.Impulse);
            isJumping = false;
        } 
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
