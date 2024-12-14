using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("Mouse Settings")]
    public float mouseSensitivity = 100f; // Adjusted default sensitivity for smoother Mac experience
    public Transform playerBody;          // Root object of the player
    public bool invertYAxis = false;      // Option to invert Y-axis controls
    
    private float xRotation = 0f;

    void Start()
    {
        // Lock cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Adjust Y-axis rotation (invert if needed)
        if (invertYAxis)
            xRotation += mouseY;
        else
            xRotation -= mouseY;

        // Clamp the vertical rotation
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply rotation to the camera (this GameObject)
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate the player body horizontally
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
