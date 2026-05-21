using UnityEngine;
using UnityEngine.UI;

public class SwitchUpgradeTabs : MonoBehaviour
{
    public GameObject newTab;
    public GameObject oldTab;
    public Button SwitchTabButton;
    private string currentTab;

    private void Start()
    {
        SwitchTabButton.onClick.AddListener(SwitchTab);
    }

    private void SwitchTab()
    {
        newTab.SetActive(true);
        oldTab.SetActive(false);
        currentTab = newTab.name;
    }

    public string GetCurrentTab()
    {
        return currentTab;
    }
}
