using System.Reflection;
using UnityEngine;

public class ResourcePickup : MonoBehaviour
{
    public PlayerAttributes playerAttributes;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Resource"))
        {
            ResourceAttributes resource = other.gameObject.GetComponent<ResourceAttributes>();
            playerAttributes.AddResource(resource.GetResourceType(), resource.GetResourceQuantity());
            Destroy(other.gameObject);
        }
    }
}
