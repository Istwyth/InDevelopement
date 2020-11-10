using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_Fire : MonoBehaviour
{

    [SerializeField] private float firingPower;
    [SerializeField] private float delayTime = 1;
    private Transform parent;
    
    
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private float GetParentZRotation()
    {
        Debug.Log("Rotation of Parent: " + parent.rotation.eulerAngles.z);
        return parent.rotation.eulerAngles.z;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.GetComponent<Rigidbody2D>() != null)
        {
            Rigidbody2D otherRigidbody2D = other.GetComponent<Rigidbody2D>();
            Vector2 firingForce = new Vector2(0, firingPower);
            firingForce = Quaternion.Euler(0, 0, GetParentZRotation()) * firingForce;

            otherRigidbody2D.AddForce(firingForce);
        } 
        else
        {
            Debug.Log("No Rigidbody to fire in " + "Cannon_Fire" + " on " + gameObject.name);
            
        }
    }


}
