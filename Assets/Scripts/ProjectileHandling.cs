using UnityEngine;

public class ProjectileHandling : MonoBehaviour
{
    public Rigidbody rb;

    public void Awake()
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
