using UnityEngine;
using System.Collections.Generic;

public class BuildingStatus : MonoBehaviour
{
    public List<List<GameObject>> buildingsStatus;
    public List<GameObject> blacksmiths;
    public List<GameObject> buildings;
    public static List<string> activeBuildings;
    private bool upgradedBuilding = false;

    void Start()
    {
        if (buildingsStatus == null)
        {
            buildingsStatus = new List<List<GameObject>>()
            {
                blacksmiths
            };
        }
        if (activeBuildings == null)
        {
            activeBuildings = new List<string>();
        }
        foreach (string item in activeBuildings)
        {
            Debug.Log(item);
        }
        LoadBuildings(buildingsStatus);
    }

    public List<List<GameObject>> GetBuildings()
    {
        return buildingsStatus;
    }


    public void BuildBuilding(GameObject newBuilding, GameObject oldBuilding)
    {
        activeBuildings.Add(newBuilding.name);
        activeBuildings.Remove(oldBuilding.name);
    }

    public void LoadBuildings(List<List<GameObject>> buildingsStatus)
    {
        foreach (List<GameObject> buildingType in buildingsStatus)
        {
            foreach (GameObject building in buildingType)
            {
                if (activeBuildings.Contains(building.name))
                {
                    building.SetActive(true);
                    upgradedBuilding = true;
                }
                else
                {
                    building.SetActive(false);
                }
            }
            if (!upgradedBuilding)
            {
                buildingType[0].SetActive(true);
                upgradedBuilding = false;
            }
        }
    }
}
