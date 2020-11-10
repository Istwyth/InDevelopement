using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotation : MonoBehaviour
{
    Rigidbody2D rb;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb != null)
        {
            rb.AddTorque(0.1f);
        }
        else
        {
            Debug.Log("No RIGIDBODY2D at: " + gameObject.name + " in SCRIPT: " + this.name);
        }
    }
}
