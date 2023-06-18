using System;
using UnityEngine;

namespace Player
{
    public class RangedWeapon : MonoBehaviour
    {
        [SerializeField] private GameObject _projectile;
        [SerializeField] private int _numberOfProjectiles;
        [SerializeField] private float _shotsPerSecond;
        [SerializeField] private float _projectileSpeed;
        [SerializeField] private float _rotX;
        [SerializeField] private float _rotY;
        [SerializeField] private float _rotZ;
        private float _amountY = -.5f;
        private float _amountX = -1.5f;
        private float _amountZ = .4f;
    

        private float _timeSinceLastShot = 0;

        private void Update()
        {
            _timeSinceLastShot += Time.deltaTime;
            if (Input.GetMouseButton(0))
            {
                Shoot(GetComponent<Collider>());
            }
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
                projectile.transform.position = new Vector3(position.x,
                    position.y, position.z);
                projectile.transform.rotation = Quaternion.Euler(
                    new Vector3(Camera.main.transform.rotation.eulerAngles.x,
                        playerCollider.transform.rotation.eulerAngles.y+ _rotX * (float) Math.Cos(playerCollider.transform.rotation.eulerAngles.y * Math.PI/180),
                        _rotZ));
                Debug.Log(_rotX * (float) Math.Cos(playerCollider.transform.rotation.eulerAngles.y));
                projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * _projectileSpeed, ForceMode.Impulse);
            }
        }


    }
}
