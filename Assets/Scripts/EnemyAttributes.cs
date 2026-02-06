using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;

public class EnemyAttributes : MonoBehaviour
{
    private float CurrentHealth;
    public float MaxHealth;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered");
        if (other.gameObject.GetComponent<ProjectileAttributes>())
        {
            ProjectileAttributes attributes = other.gameObject.GetComponent<ProjectileAttributes>();
            CurrentHealth = CurrentHealth - attributes.Damage;
            Debug.Log("Damage recieved");
            CheckHealth();
        }
    }

    private void CheckHealth()
    {
        if (CurrentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
