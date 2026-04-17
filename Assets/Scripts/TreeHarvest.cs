using UnityEngine;

public class TreeHarvest : MonoBehaviour
{
    private float CurrentHealth;
    public float MaxHealth;
    private bool canTakeDamage = true;
    private Animator treeAnim;
    public GameObject logs;

    private void Start()
    {
        CurrentHealth = MaxHealth;
        treeAnim = GetComponent<Animator>();
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
        Debug.Log("Current tree health: " + CurrentHealth);
        if (CurrentHealth <= 0)
        {
            treeAnim.SetTrigger("TreeCanFall");
            Invoke("TreeDestroyed", 2);
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

    private void TreeDestroyed()
    {
        Instantiate(logs, this.transform.position + Vector3.up * 3f, this.transform.rotation);
        Destroy(this.gameObject);
    }
}
