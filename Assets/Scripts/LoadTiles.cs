using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTiles : MonoBehaviour
{
    public GameObject spawnLocation;
    public void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Tile1", LoadSceneMode.Additive);
        other.transform.position = spawnLocation.transform.position;
        AsyncOperation camp = SceneManager.LoadSceneAsync("Camp", LoadSceneMode.Additive);
        camp.allowSceneActivation = false;
    }
}
