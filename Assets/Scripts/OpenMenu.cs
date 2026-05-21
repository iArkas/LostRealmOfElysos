using UnityEngine;

public class OpenMenu : MonoBehaviour, IInteractable
{
    public GameObject menu;

    public void Interact()
    {
        menu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }
}
