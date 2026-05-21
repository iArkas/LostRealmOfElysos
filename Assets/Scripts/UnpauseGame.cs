using UnityEngine;
using UnityEngine.UI;

public class UnpauseGame : MonoBehaviour
{
    public Button continueButton;
    public GameObject pauseMenu;
    public void Start()
    {
        continueButton.onClick.AddListener(ContinueGame);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
