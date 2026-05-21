using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.ProBuilder;

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
            RaycastHit hit;
            if (Physics.Raycast(pCamera.transform.position, pCamera.transform.TransformDirection(Vector3.forward), out hit, 20f))
            {
                var targetRotation = Quaternion.LookRotation(hit.point - player.transform.position);
                Instantiate(projectile, player.transform.position, targetRotation);
            }
            else
            {
                Vector3 endPos = pCamera.transform.position + pCamera.transform.TransformDirection(Vector3.forward) * 20f;
                var targetRotation = Quaternion.LookRotation(endPos - player.transform.position);
                Instantiate(projectile, player.transform.position, targetRotation);
            }
            canFire = false;
            Invoke("FireCooldown", 1f);
        }
    }

    private void FireCooldown()
    {
        canFire = true;
    }
}
