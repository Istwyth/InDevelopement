using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBehaviour : MonoBehaviour
{

    public float Hitpoints;
    public float MaxHitPoints;
    public HealthBarBehaviour HealthBar;

    // Start is called before the first frame update
    void Start()
    {
        Hitpoints = MaxHitPoints;
        HealthBar.SetHealth(Hitpoints, MaxHitPoints);
    }

    // Update is called once per frame
    public void TakeHit(float damage)
    {
        Hitpoints -= damage;
        HealthBar.SetHealth(Hitpoints, MaxHitPoints);
        if(Hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
