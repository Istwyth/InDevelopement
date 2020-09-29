using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    public bool facingRight = false;
    public bool facingUp = true;
    public bool facingDown = false;
    public bool facingLeft = false;
    

    // Update is called once per frame
    void Update()
    {
       ProcessInputs(); 
    }

    void FixedUpdate()
    {
        Move();
    }

    private void rotate()
    {
        if (Input.GetButtonDown("d"))
        {
            facingRight = true;
            facingUp = false;
            transform.Rotate(0f,90f, 0f);

        }
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        
        moveDirection = new Vector2(moveX, moveY).normalized;
        
    }

    void Move()
    {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

}
