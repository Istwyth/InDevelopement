using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    
    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;
    private bool isJumping = false;


    // Awake is called before the Start method
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // will look for a component on this GameObject

    }

     // Update is called once per frame
    void Update()
    {
        //Get player inputs
        ProcessInputs();

        //Animate
        Animate();
        
    }

    private void FixedUpdate()
    {
        //Move
        Move();
    }

    private void ProcessInputs()
    {
        moveDirection = Input.GetAxis("Horizontal");// Scale being left -1, right 1
        if(Input.GetButtonDown("Jump"))
        {
            isJumping = true;
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
