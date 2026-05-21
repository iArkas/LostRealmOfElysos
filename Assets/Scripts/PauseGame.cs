using UnityEngine;
using UnityEngine.InputSystem;

public class PauseGame : MonoBehaviour
{
    private InputAction pauseAction;
    public GameObject pauseMenu;

    public void Start()
    {
        pauseAction = InputSystem.actions.FindAction("Pause");
    }

    public void Update()
    {
        if (pauseAction.WasPressedThisFrame() && !pauseMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
    }
}
