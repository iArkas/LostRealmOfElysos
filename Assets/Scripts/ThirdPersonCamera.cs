using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform orientation;
    public Transform player;
    public Rigidbody rb;
    public Transform combatOrientation;

    public float rotationSpeed;

    public GameObject defaultCamera;
    public GameObject focusCamera;

    public CameraStyle currentStyle;

    public enum CameraStyle
    {
        Default,
        Focus
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  
        Cursor.visible = false;
    }

    private void Update()
    {
        //rotate orientation
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        //rotate player object
        if (currentStyle == CameraStyle.Default)
        {
            InputAction moveAction = InputSystem.actions.FindAction("Move");
            Vector2 moveVector = moveAction.ReadValue<Vector2>();
            Vector3 inputDir = orientation.forward * moveVector.y + orientation.right * moveVector.x;

            if (inputDir != Vector3.zero)
            {
                player.forward = Vector3.Slerp(player.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
            }
        }
        else if (currentStyle == CameraStyle.Focus)
        {
            Vector3 dirToCombatOrientaiton = combatOrientation.position - new Vector3(transform.position.x, combatOrientation.position.y, transform.position.z);
            orientation.forward = dirToCombatOrientaiton.normalized;

            player.forward = dirToCombatOrientaiton;
        }

        //switch camera
        InputAction aimAction = InputSystem.actions.FindAction("Aim");
        if (aimAction.WasPressedThisFrame())
        {
            Aiming(aimAction);
        }
        else if (aimAction.WasReleasedThisFrame())
        {
            Aiming(aimAction);
        }
    }

    private void SwitchCameraStyle(CameraStyle newStyle)
    {

        defaultCamera.SetActive(false);
        focusCamera.SetActive(false);
        Debug.Log(currentStyle);

        if (newStyle == CameraStyle.Default) defaultCamera.SetActive(true);
        if (newStyle == CameraStyle.Focus) focusCamera.SetActive(true);

        currentStyle = newStyle;
    }
    private void Aiming(InputAction aimAction)
    {
        if (aimAction.IsPressed())
        {
            SwitchCameraStyle(CameraStyle.Focus);
        }
        else
        {
            SwitchCameraStyle(CameraStyle.Default);
        }
    }
}
