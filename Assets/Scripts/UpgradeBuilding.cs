using UnityEngine;
using UnityEngine.InputSystem;

public class UpgradeBuilding : MonoBehaviour
{
    public GameObject nextBuildingUpgrade;
    public PlayerAttributes playerAttributes;
    public BuildingStatus buildingStatus;
    public string resourceTypeNeeded;
    public int resourceCost;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.transform.parent.CompareTag("Player"))
        {
            //display cost
            var buildings = buildingStatus.GetBuildings();
            InputAction interact = InputSystem.actions.FindAction("Interact");
            if (interact.WasPressedThisFrame())
            {
                if (playerAttributes.GetResource(resourceTypeNeeded) >= resourceCost)
                {
                    playerAttributes.RemoveResource(resourceTypeNeeded, resourceCost);
                    buildingStatus.BuildBuilding(nextBuildingUpgrade, this.gameObject);
                    this.gameObject.SetActive(false);
                    nextBuildingUpgrade.SetActive(true);
                }
            }
        }
    }
}