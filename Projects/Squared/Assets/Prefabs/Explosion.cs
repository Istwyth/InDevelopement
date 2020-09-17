using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float deleteTimer;

    // Update is called once per frame
    void Update()
    {
        deleteTimer -= Time.deltaTime; 
        if(deleteTimer < 0)
        {
            Destroy(gameObject);
        }
    }
}
