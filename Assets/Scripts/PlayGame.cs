using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{
    public Button playButton;

    public void Start()
    {
        playButton.onClick.AddListener(StartGame);
    }

    public void StartGame()
    {
        //inject save file
        SceneManager.LoadScene("Camp");
    }
}
