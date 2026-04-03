using System;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform orientation;
    public Transform player;
    public Rigidbody rb;
    public Transform combatOrientation;
    public PlayerMovement playerMovement;

    public float rotationSpeed;

    public GameObject defaultCamera;
    public GameObject focusCamera;
    private GameObject currentCamera;

    public CameraStyle currentStyle = CameraStyle.Default;

    public enum CameraStyle
    {
        Default,
        Focus
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  
        Cursor.visible = false;
        currentCamera = defaultCamera;
    }

    private void Update()
    {
        //rotate orientation
        Vector3 viewDir = player.position - new Vector3(currentCamera.transform.position.x, player.position.y, currentCamera.transform.position.z);
        orientation.forward = viewDir.normalized;

        //switch camera
        InputAction aimAction = InputSystem.actions.FindAction("Aim");
        if (aimAction.WasPressedThisFrame())
        {
            SwitchCameraStyle(CameraStyle.Focus);
        }
        else if (aimAction.WasReleasedThisFrame())
        {
            SwitchCameraStyle(CameraStyle.Default);
        }

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
            Vector3 dirToCombatOrientaiton = combatOrientation.position - new Vector3(currentCamera.transform.position.x, combatOrientation.position.y, currentCamera.transform.position.z);
            orientation.forward = dirToCombatOrientaiton.normalized;

            player.forward = dirToCombatOrientaiton;
        }
    }

    private void SwitchCameraStyle(CameraStyle newStyle)
    {

        defaultCamera.SetActive(false);
        focusCamera.SetActive(false);

        if (newStyle == CameraStyle.Default)
        {
            defaultCamera.SetActive(true);
            currentCamera = defaultCamera;
            currentStyle = CameraStyle.Default;
            playerMovement.moveSpeed = 5f;
        }
        if (newStyle == CameraStyle.Focus)
        {
            focusCamera.SetActive(true);
            currentCamera = focusCamera;
            currentStyle = CameraStyle.Focus;
            playerMovement.moveSpeed = 1f;
        }
    }
}
