using UnityEngine;

namespace Player
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float lifeTime = 2;
        [SerializeField] private float damage = 1;

        private void Awake()
        {
            Destroy(gameObject, lifeTime);
        }
    
        private void OnCollisionEnter(Collision collision)
        {
            DamageableEntity de = collision.gameObject.GetComponent<DamageableEntity>();
            if (de)
            {
                float dealtDamage = de.DealDamage(damage);
                if (dealtDamage >= damage)
                {
                    Destroy(gameObject);
                }
                else
                {
                    damage -= dealtDamage;
                }
            }
        }
    }
}
