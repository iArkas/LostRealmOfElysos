using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    public GameObject defaultCamera;
    public LayerMask player;
    public GameObject LastInteract;

    
    void Update()
    {
        InputAction interact = InputSystem.actions.FindAction("Interact");
        if (interact.triggered)
        {
            RaycastHit hit;
            Debug.DrawRay(defaultCamera.transform.position, defaultCamera.transform.TransformDirection(Vector3.forward * 10f), Color.blue, 10f);
            if (Physics.Raycast(defaultCamera.transform.position, defaultCamera.transform.TransformDirection(Vector3.forward * 10f), out hit, 20f, ~player))
            {
                InteractWithObject(hit.collider.gameObject);
            }
        }
    }

    public void InteractWithObject(GameObject obj)
    {
        if (obj.TryGetComponent(out IInteractable interactable))
        {
            interactable.Interact();
            LastInteract = obj;
        }
    }
}
