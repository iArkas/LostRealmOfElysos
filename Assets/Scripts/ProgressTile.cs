using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressTile : MonoBehaviour
{
    public static int level = 0;

    private void OnTriggerEnter(Collider other)
    {
        
        if (level == 3)
        {
            Debug.Log("Level is " + level);
            SceneManager.LoadScene("Camp");
            level = 0;
        }
        else
        {
            Debug.Log("Level is " + level);
            level++;
            SceneManager.LoadScene("Tile" + level);
        }
    }

    public void ResetLevel()
    {
        level = 0;
    }
}