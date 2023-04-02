using UnityEngine;
using Random = UnityEngine.Random;

public class RangedWeapon : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private int _numberOfProjectiles;
    [SerializeField] private float _shotsPerSecond;
    [SerializeField] private float _projectileSpeed;

    private float _timeSinceLastShot = 0;

    private void Update()
    {
        _timeSinceLastShot += Time.deltaTime;
    }

    public void Shoot(Collider playerCollider)
    {
        if (_timeSinceLastShot >= (1/_shotsPerSecond))
        {
            _timeSinceLastShot = 0;
            FireProjectiles(playerCollider);
        }
    }

    private void FireProjectiles(Collider playerCollider)
    {
        for (int i = 0; i < _numberOfProjectiles; i++)
        {
            Vector3 position = transform.position;
            GameObject projectile = Instantiate(_projectile, transform.position, transform.localRotation);
            Physics.IgnoreCollision(projectile.GetComponent<Collider>(), playerCollider);
            projectile.transform.position = new Vector3(position.x + Random.Range(-transform.localScale.x/2, transform.localScale.x/2),
                position.y + Random.Range(-transform.localScale.y/2, transform.localScale.y/2), position.z);
            projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * _projectileSpeed, ForceMode.Impulse);
        }
    }


}
