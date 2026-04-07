using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class BowFiring : MonoBehaviour
{

    public ThirdPersonCamera cameraScript;
    private InputAction attackAction;
    private bool canFire = true;

    public GameObject projectile;
    public Transform player;

    public GameObject pCamera;

    void Update()
    {
        attackAction = InputSystem.actions.FindAction("Attack");
        if (cameraScript.currentStyle == ThirdPersonCamera.CameraStyle.Focus && attackAction.WasPressedThisFrame() && canFire)
        {
            Vector3 endPos = pCamera.transform.position + pCamera.transform.TransformDirection(Vector3.forward) *20f;
            var targetRotation = Quaternion.LookRotation(endPos - player.transform.position);
            Instantiate(projectile, player.transform.position, targetRotation);
            canFire = false;
            Invoke("FireCooldown", 1);
        }
    }

    private void FireCooldown()
    {
        canFire = true;
    }
}
