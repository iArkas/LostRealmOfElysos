using UnityEngine;

public class BowFiring : MonoBehaviour
{

    public ThirdPersonCamera cameraScript;

    void Update()
    {
        if (cameraScript.currentStyle == ThirdPersonCamera.CameraStyle.Focus)
        {
            Debug.Log("Bow Script executed");
        }
    }
}
