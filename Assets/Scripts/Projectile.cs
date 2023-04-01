using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float lifeTime = 2;
    private float damage = 0;

    private void Start()
    {
        Destroy(this, lifeTime);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        DamageableEntity de = collision.gameObject.GetComponent<DamageableEntity>();
        if (de)
        {
            float dealtDamage = de.DealDamage(damage);
            if (dealtDamage >= damage)
            {
                Destroy(this);
            }
            else
            {
                damage -= dealtDamage;
            }
        }
    }
}
