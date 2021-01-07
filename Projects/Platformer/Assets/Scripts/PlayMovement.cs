using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private float moveDirection;
    public bool facingRight = true;
    public bool isMoving = false;
    public float moveSpeed;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        ProcessInputs();
        Animate();
    }

    private void ProcessInputs()
    {
        moveDirection = Input.GetAxis("Horizontal");
        
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

     public void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f,180f, 0f);
    }

    private void FixedUpdate()
    {    
       
        Move();

    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        
    }

}
