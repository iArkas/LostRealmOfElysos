using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class UpgradeWeapon : MonoBehaviour
{
    public static int bowLevel = 0;
    public PlayerAttributes playerAttributes;
    public Dictionary<int,int> bowUpgradeCost;
    private InputAction interactAction;
    private int cost;
    public ProjectileAttributes projectileAttributes;

    public void Start()
    {
        bowUpgradeCost = new Dictionary<int,int>()
        {
            {1, 100 },
            {2, 150 },
            {3, 200 }
        };
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger entered");
        foreach (int dictKey in bowUpgradeCost.Keys)
        {
            Debug.Log(dictKey);
            if (dictKey == bowLevel + 1)
            {
                cost = bowUpgradeCost[dictKey];
                Debug.Log(cost);
            }
        }
        //display upgrade cost
    }

    public void OnTriggerStay(Collider other)
    {
        interactAction = InputSystem.actions.FindAction("Interact");
        if (interactAction.WasPressedThisFrame())
        {
            Debug.Log("Interact pressed");
            int gold = playerAttributes.GetResource("gold");
            if (gold > cost)
            {
                playerAttributes.RemoveResource("gold", cost);
                bowLevel++;
                projectileAttributes.damage += projectileAttributes.damage + 10;
            }
            else { Debug.Log("Not enough gold"); }
        }
    }
}
