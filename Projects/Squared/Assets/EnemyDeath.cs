using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public void OnDeath()
    {
        Debug.Log("FUCKING DEAD CUNT");
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
