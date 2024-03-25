using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FirstPersonCamera : MonoBehaviour
{
    public float moveSpeed = 100.0f;
    public float rotationSpeed = 2.0f;

    private bool isMouseLocked = true; // Indicates whether the mouse is locked

    private void Start()
    {
        LockMouseCursor();
    }

    private void Update()
    {
        // Toggle mouse lock with the "Escape" key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMouseLock();
        }

        // Unlock the mouse cursor with the middle mouse button
        if (Input.GetMouseButtonDown(2)) // 2 corresponds to the middle mouse button
        {
            UnlockMouseCursor();
        }

        if (isMouseLocked)
        {
            // Camera movement
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

            // Camera rotation
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            Vector3 rotation = new Vector3(-mouseY, mouseX, 0) * rotationSpeed;
            transform.eulerAngles += rotation;
        }
    }

    private void ToggleMouseLock()
    {
        isMouseLocked = !isMouseLocked;
        if (isMouseLocked)
        {
            LockMouseCursor();
        }
        else
        {
            UnlockMouseCursor();
        }
    }

    private void LockMouseCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void UnlockMouseCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}