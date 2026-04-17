using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressTile : MonoBehaviour
{
    public static int level = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (level ==3 )
        {
            SceneManager.LoadScene("Camp");
        }
        else
        {
            level++;
            SceneManager.LoadScene("Tile" + level);
        }
    }

    public void ResetLevel()
    {
        level = 0;
    }
}

