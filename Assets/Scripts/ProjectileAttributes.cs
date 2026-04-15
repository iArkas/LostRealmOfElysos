using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ProjectileAttributes : MonoBehaviour
{
    public float damage = 50;
    public Rigidbody rb;

    public void Awake()
    {
        Invoke("Fire", 1);
    }

    public void Fire()
    {
        rb.GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.AddForce(transform.rotation * Vector3.forward * 1000f);
        Invoke("SelfExit", 3);
    }

    private void SelfExit()
    {
        Destroy(this.gameObject);
    }
}
