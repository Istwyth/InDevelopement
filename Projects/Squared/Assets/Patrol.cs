using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool movingRight = true;

    public Transform groundDetection;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        if (!groundInfo.collider)
        {
            if (movingRight)
            {
                FlipCharacter();
            } else {
                FlipCharacter();
            }
        }
    }

    public void FlipCharacter()
    {
        movingRight = !movingRight;
        if (movingRight)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        } else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    public bool GetMovingRight()
    {
        return movingRight;
    }
}
