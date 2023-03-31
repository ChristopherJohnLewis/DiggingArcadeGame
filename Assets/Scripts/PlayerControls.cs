using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float moveSpeed = 5f; // The speed at which the player moves
    public float jumpForce = 10f; // The force with which the player jumps
    private float horizontalMovement; // The horizontal input from the user
    private float verticalMovement; // The vertical input from the user
    private Rigidbody playerRigidbody; // The player's rigidbody component

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>(); // Get the player's rigidbody component
    }

    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal"); // Get the horizontal input from the user
        verticalMovement = Input.GetAxisRaw("Vertical"); // Get the vertical input from the user

        if (Input.GetButtonDown("Jump")) // If the user presses the jump button
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Add upward force to the player's rigidbody
        }
    }

    void FixedUpdate()
    {
        Vector3 forward = Camera.main.transform.forward; // Get the camera's forward vector
        forward.y = 0; // Set the y component to 0 to prevent the player from moving up or down
        forward = forward.normalized; // Normalize the forward vector to get a direction vector

        Vector3 right = Camera.main.transform.right; // Get the camera's right vector
        right.y = 0; // Set the y component to 0 to prevent the player from moving up or down
        right = right.normalized; // Normalize the right vector to get a direction vector

        Vector3 movement = new Vector3(horizontalMovement, 0f, verticalMovement); // Create a movement vector based on the user's input
        movement = (forward * verticalMovement + right * horizontalMovement).normalized * moveSpeed * Time.fixedDeltaTime; // Scale the movement vector by the moveSpeed and deltaTime, taking into account the player's direction
        playerRigidbody.MovePosition(transform.position + movement); // Move the player's rigidbody
    }

}
