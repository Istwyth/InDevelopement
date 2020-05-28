using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    private Direction currentDirection;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        currentDirection = Direction.UP;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void moveUpdate()
    {
        Debug.Log("I'm moving " + currentDirection.ToString());
        movePiece();
    }

    public void movePiece()
    {
        if (rb == null) {
            transform.Translate(currentDirection.GetVector(), Space.World);
        } else
        {
            rb.MovePosition(rb.position + currentDirection.GetVector());
        }
    }

    public Direction GetDirection()
    {
        return currentDirection;
    }

    public void SetDirection(Direction newDir)
    {
        currentDirection = newDir;
    }

    public Rigidbody2D GetRigidbody()
    {
        return rb;
    }

    public void SetRigidbody(Rigidbody2D newRb)
    {
        rb = newRb;
    }
}
