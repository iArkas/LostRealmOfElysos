using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;

public class EnemyAttributes : MonoBehaviour
{
    private float CurrentHealth;
    public float MaxHealth;
    private bool canTakeDamage = true;
    public int value;

    public PlayerAttributes playerAttributes;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered");
        if (other.transform.parent.gameObject.GetComponent<ProjectileAttributes>())
        {
            TakeDamage(other);
            Debug.Log("Enemy hit");
        }
    }

    private void CheckHealth()
    {
        Debug.Log("Current enemy health: " + CurrentHealth);
        if (CurrentHealth <= 0)
        {
            playerAttributes.AddCurrency(value);
            Destroy(this.gameObject);
        }
    }

    private void TakeDamage(Collider other)
    {
        if (canTakeDamage)
        {
            ProjectileAttributes attributes = other.transform.parent.gameObject.GetComponent<ProjectileAttributes>();
            CurrentHealth = CurrentHealth - attributes.Damage;
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
