using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask groundMask;

    [SerializeField]
    private float acceleration = 0.2f;
    [SerializeField]
    private float minSpeed = 12f;
    [SerializeField]
    private float maxSpeed = 20f;
    [SerializeField]
    private float gravity = -9.81f;
    [SerializeField]
    private float jumpHeight = 3f;
    [SerializeField]
    private float groundDistance = 0.4f;

    private float speed;
    private Vector3 velocity;
    private bool isGrounded;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        speed = minSpeed;
    }

    private void Update()
    {
        checkIfIsGrounded();
        applyGravity();
        walking();
        running();
        jumping();

        Debug.Log("°-°   " + speed);
    }

    private void checkIfIsGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    private void applyGravity()
    {
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void walking()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }

    private void running()
    {
        if (Input.GetButton("Run") && isGrounded)
        {
            if(speed < maxSpeed)
            {
                speed += acceleration;
            }
        }
        else
        {
            if (speed > minSpeed)
            {
                speed -= acceleration;
            }
        }
    }

    private void jumping()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
