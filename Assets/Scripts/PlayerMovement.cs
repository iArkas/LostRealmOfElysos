using System;
using System.Security;
using UnityEditor.Rendering;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Transform orientation;

    Vector2 moveVector;

    Vector3 moveDirection;
    Rigidbody rb;

    public float playerHeight;
    public LayerMask ground;
    bool grounded;
    public float groundDrag;

    public float jumpForce;


    bool playingSFX = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        InputAction moveAction = InputSystem.actions.FindAction("Move");
        InputAction jumpAction = InputSystem.actions.FindAction("Jump");
        moveVector = moveAction.ReadValue<Vector2>();

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ground);
        if (grounded)
            rb.linearDamping = groundDrag;
        else
            rb.linearDamping = 0;

        SpeedControl();

        if (moveVector.x != 0 || moveVector.y !=0)
        {
            if (playingSFX == false || !grounded)
            {
                GetComponent<AudioSource>().Play();
                playingSFX = true;
            }
        }
        else
        {
            playingSFX = false;
            GetComponent<AudioSource>().Stop();
        }

        if (jumpAction.triggered)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * moveVector.y + orientation.right * moveVector.x;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        if (grounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.y);
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }
}