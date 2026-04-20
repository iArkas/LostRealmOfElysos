using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject player;
    void Awake()
    {
        player.SetActive(true);
    }
}
