using System.Collections.Generic;
using TMPro;
using UnityEditor.AdaptivePerformance.Editor;
using UnityEngine;
using UnityEngine.WSA;

public class PlayerAttributes : MonoBehaviour
{

    public TMP_Text goldQuantity;
    public TMP_Text logsQuantity;
    public static Dictionary<string, int> playerResources;

    private void Awake()
    {
        if (playerResources == null)
        {
            playerResources = new Dictionary<string, int>()
            {
                {"gold", 0 },
                {"logs", 60 }
            };
        }
    }

    public void AddResource(string resourceToAdd, int quantity)
    {
        playerResources[resourceToAdd] += quantity;
    }

    private void Update()
    {
        goldQuantity.text = playerResources["gold"].ToString();
        logsQuantity.text = playerResources["logs"].ToString();      
    }

    public int GetResource(string resourceToGet)
    {
        return playerResources[resourceToGet];
    }

    public void RemoveResource(string resourceToRemove, int quantity)
    {
        playerResources[resourceToRemove] -= quantity;
    }
}