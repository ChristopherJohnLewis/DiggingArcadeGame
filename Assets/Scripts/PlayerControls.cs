using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private float horizontalMovement;
    private float verticalMovement;
    private int _jumps;
    private Rigidbody playerRigidbody;
    
    [SerializeField] private RangedWeapon _rangedWeapon;
    [SerializeField] private GameObject _meleeWeapon;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetMouseButtonDown(0))
        {
            _rangedWeapon.Shoot(GetComponent<Collider>());
        }
    }

    void FixedUpdate()
    {
        Vector3 forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = forward.normalized;

        Vector3 right = Camera.main.transform.right;
        right.y = 0;
        right = right.normalized;

        Vector3 movement = new Vector3(horizontalMovement, 0f, verticalMovement);
        movement = (forward * verticalMovement + right * horizontalMovement).normalized * moveSpeed * Time.fixedDeltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

}
