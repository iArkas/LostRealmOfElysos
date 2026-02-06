using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToCamp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Camp");
    }
}

