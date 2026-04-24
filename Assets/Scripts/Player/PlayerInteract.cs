using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] float interactRange;
    [SerializeField] Transform cameraTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if(Physics.Raycast(cameraTransform.position,cameraTransform.forward,out hit, 5f))
            {
                if (hit.collider.gameObject.TryGetComponent<Iinteractable>(out Iinteractable component)) 
                {
                    component.Interact();
                }
            }
        }
    }
}
