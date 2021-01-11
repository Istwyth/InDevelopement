using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{

    [SerializeField] private int creatureLayers;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == creatureLayers)
        {
            Debug.Log(gameObject.name + " hit something");
        }
    }

    private void AttackObject(GameObject victim)
    {
        /*
         * victimHealth = victim.GetComponent<HealthScript>();
         * if(victimHealth != null){
         *      victimHealth.DoDamage(Damage stuff);
         * }
         *
         */
    }
}
