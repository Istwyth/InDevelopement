using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{

    [SerializeField] private int creatureLayers;
    private Animator animator = null;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == creatureLayers)
        {
            Debug.Log(gameObject.name + " hit something");
            AttackObject(collision.gameObject);
        }
    }

    public void InitiateAttack()
    {
        animator.SetTrigger("Attack");
    }

    private void AttackObject(GameObject victim)
    {
        HealthBehaviour victimHealth = victim.GetComponent<HealthBehaviour>();
        victimHealth.TakeHit(0.5f);
        
        /*
         * victimHealth = victim.GetComponent<HealthScript>();
         * if(victimHealth != null){
         *      victimHealth.DoDamage(Damage stuff);
         * }
         *
         */
    }
}
