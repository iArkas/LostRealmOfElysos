using UnityEngine;

public class ResourceAttributes : MonoBehaviour
{
    public string resourceType;
    public int resourceQuantity;

    public string GetResourceType()
    {
        return resourceType;
    }

    public int GetResourceQuantity()
    {
        return resourceQuantity;
    }
}
