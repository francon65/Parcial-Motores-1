using UnityEngine;

public class OpenElectricBox : MonoBehaviour, Iinteractable
{
    Animator animator;
    [SerializeField] BoxCollider c;
    public void Interact()
    {
        c.enabled = false;
        animator.SetTrigger("Open");
    }

    void Start()
    {
        animator = GetComponent<Animator>();
      
    }

    
}
