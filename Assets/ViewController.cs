using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ViewController : MonoBehaviour
{
    public float mouseSensitivity = 20.0f;
    public float xRotation = 1f;
    public Transform playerBody;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        var mouse = Mouse.current;

        if (mouse != null)
        {
            float mouseX = mouse.delta.x.ReadValue() * mouseSensitivity * Time.deltaTime;
            float mouseY = mouse.delta.y.ReadValue() * mouseSensitivity * Time.deltaTime;
            playerBody.Rotate(Vector3.up * mouseX);
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -80f, 45f);
            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        }

    }
}
