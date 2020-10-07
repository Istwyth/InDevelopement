using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript_Bouncy : MonoBehaviour
{

    public float projectileSpeed;
    public GameObject impactEffect; 

    private Rigidbody2D rigidBody;

    public int wallBounceMaximum = 10; 
    private int wallBounceCount = 0; 

    // Start is called before the first frame update
    void Start()
    {
        wallBounceCount = 0;
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = transform.right * projectileSpeed;

    }

   private void OnTriggerEnter2D(Collider2D collision)
   {
        if ((wallBounceCount != wallBounceMaximum) && (collision.gameObject.layer == LayerMask.NameToLayer("Ground") || collision.gameObject.layer == LayerMask.NameToLayer("Wall")))
        {
            Vector2 closestPoint = collision.ClosestPoint(transform.position);
            Vector2 normalToSurface = new Vector2(transform.position.x - closestPoint.x, transform.position.y - closestPoint.y);

            rigidBody.velocity = Vector3.Reflect(rigidBody.velocity.normalized, normalToSurface.normalized) * projectileSpeed;
            wallBounceCount++;
        }
        else
        {
            Debug.Log("Not Wall/Ground, OR time to explode?");
            Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            if (collision.GetComponent<HealthBehaviour>() != null)
            {
                collision.SendMessage("TakeHit", 1f);
            }
        }



   }


}
