using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Collections;

public class BuildingStatus : MonoBehaviour
{
    public List<List<GameObject>> buildingsStatus;
    public List<GameObject> blacksmiths;
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

    public List<GameObject> getBuildingList(string buildingType)
    {
        switch (buildingType)
        {
            case "Blacksmith":
                return blacksmiths;
            default:
                return null;

        }
    }

    public List<string> getActiveBuildings()
    {
        foreach (string i in activeBuildings)
        {
            Debug.Log(i);
        }
        return activeBuildings;
    }
}