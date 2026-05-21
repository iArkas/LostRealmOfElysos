using UnityEngine;
using UnityEngine.UI;

public class CloseMenu : MonoBehaviour
{
    public Button closeMenu;
    public GameObject menu;

    void Start()
    {
        closeMenu.onClick.AddListener(CloseMenuF);
    }

    void CloseMenuF()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
