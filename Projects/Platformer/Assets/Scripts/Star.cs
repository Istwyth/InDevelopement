using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
   
    public int starValue = 1;

    private void OnTriggerEnter2D(Collider2D starCounter)
    {
        if(starCounter.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.ChangeScore(starValue);
            Destroy(gameObject);
        }
    }

}
