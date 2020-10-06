using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float _speed = 2f;
    public float gravity = -9.81f;
    public CharacterController controller;
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    private bool isGrounded;
    private Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;
        var mouse = Mouse.current;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (keyboard != null)
        {
            if (keyboard.wKey.isPressed || keyboard.upArrowKey.wasPressedThisFrame)
            {
                Vector3 movement = (Vector3.forward * _speed * Time.deltaTime);
                movement = transform.TransformDirection(movement);
                controller.Move(movement);
                //UnityEngine.Debug.Log("The character is moving forward");
            }
            if (keyboard.sKey.isPressed || keyboard.downArrowKey.wasPressedThisFrame)
            {
                Vector3 movement = (Vector3.back * _speed * Time.deltaTime);
                movement = transform.TransformDirection(movement);
                controller.Move(movement);
                //UnityEngine.Debug.Log("The character is moving backward");
            }
            if (keyboard.aKey.isPressed || keyboard.leftArrowKey.wasPressedThisFrame)
            {
                Vector3 movement = (Vector3.left * _speed * Time.deltaTime);
                movement = transform.TransformDirection(movement);
                controller.Move(movement);
               // UnityEngine.Debug.Log("The character is moving left");
            }
            if (keyboard.dKey.isPressed || keyboard.rightArrowKey.wasPressedThisFrame)
            {
                Vector3 movement = (Vector3.right * _speed * Time.deltaTime);
                movement = transform.TransformDirection(movement);
                controller.Move(movement);
               // UnityEngine.Debug.Log("The character is moving right");
            }
        }

        if (mouse != null)
        {
            if (mouse.leftButton.wasPressedThisFrame)
            {
                //UnityEngine.Debug.Log("Left Mouse Button Pressed");
            }
            if (mouse.rightButton.wasPressedThisFrame)
            {
                //UnityEngine.Debug.Log("Right Mouse Button is Held Down");
            }
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
