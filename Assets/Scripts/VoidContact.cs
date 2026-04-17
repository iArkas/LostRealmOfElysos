using UnityEngine;
using UnityEngine.SceneManagement;

public class VoidContact : MonoBehaviour
{
    public ProgressTile progressTile;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Camp");
            progressTile.ResetLevel();
        }
    }
}
