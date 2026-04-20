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
        if (pauseAction.WasPressedThisFrame())
        {
            Time.timeScale = 0;
            Instantiate(pauseMenu);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
