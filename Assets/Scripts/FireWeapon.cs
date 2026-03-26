using UnityEngine;
using UnityEngine.Animations;
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

            Bow.GetComponent<AudioSource>().Play();
            RaycastHit hit;
            Vector3 endPos = PCamera.transform.position + PCamera.transform.TransformDirection(Vector3.forward) * 20f;
            Vector3 targetPosition = new Vector3(endPos.x, Player.transform.position.y, endPos.z);
            Player.transform.LookAt(targetPosition);
            
            Player.GetComponent<Rigidbody>().freezeRotation = true;
            if (Physics.Raycast(PCamera.transform.position, PCamera.transform.TransformDirection(Vector3.forward), out hit, 20f))
            {
                var targetRotation = Quaternion.LookRotation(hit.point - Player.transform.position);
                Instantiate(Projectile, Bow.transform.position, targetRotation);
                Bow.GetComponent<Animator>().SetTrigger("PlayBow");
            }
            else
            {
                Vector3 newEndPos = PCamera.transform.position + PCamera.transform.TransformDirection(Vector3.forward) * 20f;
                var targetRotation = Quaternion.LookRotation(newEndPos - Player.transform.position);
                Instantiate(Projectile, Bow.transform.position, targetRotation);
                Bow.GetComponent<Animator>().SetTrigger("PlayBow");
            }
            canFire = false;
            Invoke("FireCooldown", 1f);
        }
    }
    
    private void FireCooldown()
    {
        Player.GetComponent<Rigidbody>().freezeRotation=false;
        canFire = true;
        Bow.GetComponent<Animator>().ResetTrigger("PlayBow");
    }
}
