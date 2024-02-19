using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float JumpHeight;

    public float movementSpeed = 12;
    public float gravity = -0.98f;
    public float groundDistance = 0.4f;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * movementSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump pressed. Grounded: " + isGrounded);
            if (isGrounded)
            {
                velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
            }
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
