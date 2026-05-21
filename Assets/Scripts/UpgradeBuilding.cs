using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UpgradeBuilding : MonoBehaviour
{
    private GameObject nextBuildingUpgrade;
    public PlayerAttributes playerAttributes;
    public BuildingStatus buildingStatus;
    private string resourceTypeNeeded;
    private int resourceCost;
    public PlayerInteract playerInteract;
    public Button upgradeButton;
    public SwitchUpgradeTabs tabs;
    private GameObject oldBuilding;

    private void Awake()
    {
        upgradeButton.onClick.AddListener(DoBuildingUpgrade);
    }

    private void DoBuildingUpgrade()
    {
        string currentTab = tabs.GetCurrentTab();
        List<GameObject> Buildings = buildingStatus.getBuildingList(currentTab);
        foreach (GameObject building in Buildings)
        {
            if (buildingStatus.getActiveBuildings().Contains(building.name))
            {
                oldBuilding = building;
            }else
            {
                oldBuilding = Buildings[0];
            }
        }
        GameObject lastInteract = playerInteract.LastInteract;
        resourceTypeNeeded = lastInteract.GetComponent<UpgradeBuildingCosts>().getResourceType();
        resourceCost = lastInteract.GetComponent<UpgradeBuildingCosts>().getResourceCost();
        nextBuildingUpgrade = lastInteract.GetComponent<UpgradeBuildingCosts>().getNextBuildingUpgrade();
        if (playerAttributes.GetResource(resourceTypeNeeded) >= resourceCost)
        {
            var buildings = buildingStatus.GetBuildings();
            playerAttributes.RemoveResource(resourceTypeNeeded, resourceCost);
            buildingStatus.BuildBuilding(nextBuildingUpgrade, oldBuilding);
            oldBuilding.SetActive(false);
            nextBuildingUpgrade.SetActive(true);
        }
    }
}
