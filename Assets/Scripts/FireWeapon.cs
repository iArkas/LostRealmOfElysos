using UnityEngine;
using UnityEngine.Rendering;

public class FireWeapon : MonoBehaviour
{
    public GameObject Projectile;
    public Transform Player;
    public GameObject PCamera;
    public GameObject Bow;

    private bool canFire = true;

    private void Start()
    {
        Animator BowAnim = Bow.GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            FireProjectile();
        }
    }

    private void FireProjectile()
    {
        if (canFire)
        {
            RaycastHit hit;
            if (Physics.Raycast(PCamera.transform.position, PCamera.transform.TransformDirection(Vector3.forward), out hit, 20f))
            {
                var targetRotation = Quaternion.LookRotation(hit.point - Player.transform.position);
                Instantiate(Projectile, Player.transform.position, targetRotation);
                Bow.GetComponent<Animator>().SetTrigger("PlayBow");
            }
            else
            {
                Vector3 endPos = PCamera.transform.position + PCamera.transform.TransformDirection(Vector3.forward) * 20f;
                var targetRotation = Quaternion.LookRotation(endPos - Player.transform.position);
                Instantiate(Projectile, Player.transform.position, targetRotation);
                Bow.GetComponent<Animator>().SetTrigger("PlayBow");
            }
            canFire = false;
            Invoke("FireCooldown", 1f);
        }
    }
    
    private void FireCooldown()
    {
        canFire = true;
        Bow.GetComponent<Animator>().ResetTrigger("PlayBow");
    }
}
