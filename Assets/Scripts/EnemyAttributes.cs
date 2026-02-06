using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;

public class EnemyAttributes : MonoBehaviour
{
    private float CurrentHealth;
    public float MaxHealth;
    private bool canTakeDamage = true;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered");
        if (other.gameObject.GetComponent<ProjectileAttributes>())
        {
            TakeDamage(other);
        }
    }

    private void CheckHealth()
    {
        if (CurrentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void TakeDamage(Collider other)
    {
        if (canTakeDamage)
        {
            ProjectileAttributes attributes = other.gameObject.GetComponent<ProjectileAttributes>();
            CurrentHealth = CurrentHealth - attributes.Damage;
            Debug.Log("Damage recieved");
            CheckHealth();
            canTakeDamage = false;
            Invoke("DamageCooldown", 1);
        }
    }

    private void DamageCooldown()
    {
        canTakeDamage = true;
    }
}
