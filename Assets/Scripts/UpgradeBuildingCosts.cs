using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBuildingCosts : MonoBehaviour
{
    public GameObject nextBuildingUpgrade;
    public string resourceTypeNeeded;
    public int resourceCost;

    public string getResourceType()
    {
        return resourceTypeNeeded;
    }

    public int getResourceCost()
    {
        return resourceCost;
    }

    public GameObject getNextBuildingUpgrade()
    {
        return nextBuildingUpgrade;
    }
}