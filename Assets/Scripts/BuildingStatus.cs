using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEditor.UIElements;
using System.Linq;
using UnityEditor.Experimental.GraphView;

public class BuildingStatus : MonoBehaviour
{
    public Dictionary<string, bool> buildings;

    void Start()
    {
        if (buildings == null)
        {
            buildings = new Dictionary<string, bool>()
            {
                {"BlacksmithL1", false },
                {"BlacksmithL2", false },
                {"BlacksmithL3", false }
            };
        }
    }

    public Dictionary<string, bool> GetBuildings()
    {
        return buildings;
    }


    public void BuildBuilding(string building)
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
