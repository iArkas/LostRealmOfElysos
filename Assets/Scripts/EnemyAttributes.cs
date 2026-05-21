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
        if (other.transform.parent.gameObject.GetComponent<ProjectileAttributes>())
        {
            TakeDamage(other);
        }
    }

    private void CheckHealth()
    {
        Debug.Log("Current enemy health: " + CurrentHealth);
        if (CurrentHealth <= 0)
        {
            playerAttributes.AddResource("gold", value);
            Destroy(this.gameObject);
        }
    }

    private void TakeDamage(Collider other)
    {
        if (canTakeDamage)
        {
            ProjectileAttributes attributes = other.transform.parent.gameObject.GetComponent<ProjectileAttributes>();
            CurrentHealth = CurrentHealth - attributes.damage;
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
