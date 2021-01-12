using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour
{

    [SerializeField] private float currentHitPoints;
    [SerializeField] private float maxHitPoints;
    public HealthBarBehaviour healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHitPoints = maxHitPoints;
        healthBar.SetHealth(currentHitPoints, maxHitPoints);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetCurrentHitPoints()
    {
        return currentHitPoints;
    }

    public float GetMaxHitPoints()
    {
        return maxHitPoints;
    }

    public void SetHealthBar(HealthBarBehaviour newHealthBar)
    {
        healthBar = newHealthBar;
    }

    //Takes a hit of a certain damage from current HP. Updates health bar. Does check for if dead.
    public void TakeHit(float damage)
    {
        if (damage > 0) {
            currentHitPoints -= damage;
            healthBar.SetHealth(currentHitPoints, maxHitPoints);
            if (GetCurrentHitPoints() <= 0)
            {
                Death();
            }
        }
    }

    //Run when HP drops to 0, handles death of attached.
    virtual public void Death()
    {
        Destroy(gameObject);    //By default, destroys current object.
    }
}
