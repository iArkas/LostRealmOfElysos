using TMPro;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public static int gold;
    public TMP_Text goldQuantity;

    public void AddCurrency(int goldToAdd)
    {
        gold += goldToAdd;
    }

    private void Update()
    {
        goldQuantity.text = gold.ToString();
    }
}
