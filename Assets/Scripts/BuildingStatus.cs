using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEditor.UIElements;
using System.Linq;

public class BuildingStatus : MonoBehaviour
{
    public Dictionary<string, bool> buildings;

    void Start()
    {
        buildings.Add("BlacksmithL1", false);
        buildings.Add("BlacksmithL2", false);
        buildings.Add("BlacksmithL3", false);
    }

    private Dictionary<string, bool> getBuildings()
    {
        return buildings;
    }


    private void newBuilding(string building)
    {
        foreach (var item in buildings)
        {
            if (item.Key == building)
            {
                buildings[item.Key] = true;
            }
        }
    }
}
