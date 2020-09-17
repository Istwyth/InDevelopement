using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    public float projectileSpeed;
    public GameObject impactEffect; 

    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = transform.right * projectileSpeed;

    }

   private void OnTriggerEnter2D(Collider2D collision)
   {

       Debug.Log("TRIGGERED");
       Instantiate(impactEffect, transform.position, Quaternion.identity);
       Destroy(gameObject);
       if (collision.GetComponent<EnemyBehaviour>() != null || collision.GetComponent<PlayerHealthBehaviour>() != null)
       {
        collision.SendMessage("TakeHit", 1f);
       }


   }


}
