using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform firePosition;
    public GameObject projectile;
    public float distance;
    private bool facingRight = true;

    private bool patrol = false;

     public float time;

    private void FlipCharacter()
    {
        if (patrol)
        {
            GetComponent<Patrol>().FlipCharacter();
        }
        facingRight = !facingRight;
        transform.Rotate(0f,180f, 0f);
    }

    private void Start()
    {
        if(GetComponent<Patrol>() != null)
        {
            patrol = true;
            Debug.Log("PATROLLER");
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (time < 1)
        {
            time += Time.deltaTime;
            return;
        }

        if (patrol)
        {
            facingRight = GetComponent<Patrol>().GetMovingRight();
        }

        RaycastHit2D detectLeft = Physics2D.Raycast(transform.position, ( Vector2.left), distance, LayerMask.GetMask("Player"));
        RaycastHit2D detectRight = Physics2D.Raycast(transform.position, (Vector2.right), distance, LayerMask.GetMask("Player")); 
            if (detectLeft.transform != null)
            {
                if(detectLeft.transform.tag == "Player")
                {
                    if (facingRight)
                    {
                         FlipCharacter();
                    }

                FireWeapon();
            }
            }
            if (detectRight.transform != null)
            {  
                if(detectRight.transform.tag == "Player")
                {
                     if (!facingRight)
                    {
                        FlipCharacter();

                    }
                    FireWeapon();
            }
            }
        
    }

    private void FireWeapon()
    {
        Instantiate(projectile, firePosition.position, firePosition.rotation);
        time = 0;
    }
}

