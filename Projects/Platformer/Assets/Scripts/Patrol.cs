using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool movingRight = true;

    public Transform groundDetection;
    //public Transform wallDetection;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        Vector2 wallDirection = new Vector2(0,0);
        if (movingRight) //Technically should be NOT, but the bug is useful (Shoots ray into the enemy)
        {
            wallDirection = Vector2.right;
        } else
        {
            wallDirection = Vector2.left;
        }
        //RaycastHit2D wallInfo = Physics2D.Raycast(wallDetection.position, Vector2.down, 1.7f, LayerMask.GetMask("Wall"));
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f, LayerMask.GetMask("Ground"));

       // Debug.DrawRay(wallDetection.position, Vector2.down, Color.green, 0.0f, false);
        Debug.DrawRay(groundDetection.position, Vector2.down* 2f, Color.green, 0.0f, false);

        if (!groundInfo.collider)
        {
            Debug.Log("Ground collider not found");
            ChangeDirection();
        }
        //if (wallInfo.collider)
        //{
        //    Debug.Log("Wall collider found");
       //     ChangeDirection();
       // }
    }

    private void ChangeDirection()
    {
        if (movingRight)
        {
            FlipCharacter();
        }
        else
        {
            FlipCharacter();
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
