using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBehaviour : HealthBehaviour
{

    override public void Death()
    {
        GameObject.Find("Score").GetComponent<ScoreUpdate>().AddToScore(1);
        Destroy(gameObject);    //By default, destroys current object.
    }
}
