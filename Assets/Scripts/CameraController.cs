using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // The player's transform component
    public float sensitivity = 100f; // The sensitivity of the camera's rotation

    private float xRotation = 0f; // The x rotation of the camera

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime; // Get the horizontal mouse input
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime; // Get the vertical mouse input

        xRotation -= mouseY; // Subtract the vertical mouse input from the x rotation of the camera
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp the x rotation between -90 and 90 degrees

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Set the camera's x rotation
        player.Rotate(Vector3.up * mouseX); 
    }
}
