using TMPro;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] float interactRange;
    [SerializeField] Transform cameraTransform;
    [SerializeField] LayerMask layerToIgnore;

    [SerializeField]TextMeshProUGUI interactText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        interactText.gameObject.SetActive(false);
            RaycastHit hit;
            if(Physics.Raycast(cameraTransform.position,cameraTransform.forward,out hit, 5f, ~layerToIgnore))
            {
                if (hit.collider.gameObject.TryGetComponent<Iinteractable>(out Iinteractable component)) 
                {
                    interactText.gameObject.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        component.Interact();
                    }
                    
                }
            }
        
    }
}
