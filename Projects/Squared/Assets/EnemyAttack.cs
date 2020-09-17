using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform firePosition;
    public GameObject projectile;
    public float distance;
    private bool facingRight = true;

     public float time;

    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f,180f, 0f);
    }

    
   // Update is called once per frame
    void Update()
    {
       
        RaycastHit2D detectLeft = Physics2D.Raycast(transform.position, ( Vector2.left), distance, LayerMask.GetMask("Player")
);
        RaycastHit2D detectRight =Physics2D.Raycast(transform.position, ( Vector2.right), distance, LayerMask.GetMask("Player")
);       time += Time.deltaTime;
         if(time >= 1)
         {
             time = 0;
            if (detectLeft.transform != null)
            {
                if(detectLeft.transform.tag == "Player")
                {
                    if (facingRight)
                    {
                         FlipCharacter();
                    }
                        
                    Instantiate(projectile, firePosition.position, firePosition.rotation);
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
                     Instantiate(projectile, firePosition.position, firePosition.rotation);

                 }
            }
    }
        
    }
}

