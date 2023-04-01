using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableEntity : MonoBehaviour
{
    public float health;
    public float DealDamage(float damage)
    {
        float damageDealt = damage;
        
        health -= damage;
        
        if (health <= 0)
        {
            damageDealt = health;
            Destroy(this);
        }

        return damageDealt;
    }
}
