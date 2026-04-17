using Mono.Cecil;
using UnityEngine;
using UnityEngine.InputSystem;

public class UpgradeBuilding : MonoBehaviour
{
    public GameObject nextBuildingUpgrade;
    public PlayerAttributes playerAttributes;
    public BuildingStatus buildingStatus;
    public string resourceTypeNeeded;
    public int resourceCost;
    private bool interactPressed;

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
                    this.gameObject.SetActive(false);
                    nextBuildingUpgrade.SetActive(true);
                    playerAttributes.RemoveResource(resourceTypeNeeded, resourceCost);
                    buildingStatus.BuildBuilding(nextBuildingUpgrade.ToString());
                }
            }
        }
    }
}
