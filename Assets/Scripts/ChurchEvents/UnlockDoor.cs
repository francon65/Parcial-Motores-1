using Cinemachine;
using System.Collections;
using UnityEngine;
public class UnlockDoor : MonoBehaviour, Iinteractable
{


    [SerializeField] CinemachineFreeLook doorCamera; 

    
    public float cameraShowDuration = 3f; 
    bool triggered = false;

    [SerializeField] MeshRenderer LightColor;
    [SerializeField] Material green;
    [SerializeField] ChurchDoor churchDoor;
    [SerializeField] GameObject chaser;
    [SerializeField] Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Interact()
    {
        if(triggered) return;  
        StartCoroutine(ShowDoorCutscene());
        triggered = true;
        animator.SetTrigger("Pull");
    }

    private IEnumerator ShowDoorCutscene()
    {
        
        GetComponent<Collider>().enabled = false;
        doorCamera.Priority = 20;
        yield return new WaitForSeconds(1f);
        LightColor.material = green;    
        yield return new WaitForSeconds(cameraShowDuration);
        churchDoor.IsLocked(false);
        doorCamera.Priority = 5;
        chaser.SetActive(true);

        
    }
}
