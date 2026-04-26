using UnityEngine;

public class Door : MonoBehaviour, Iinteractable
{
    [SerializeField] string keyneeded;
    Animator animator;
    public void Interact()
    {

        if (PlayerCore.instance.GetKey(keyneeded)) 
        {
            animator.SetBool("Open", true);
            gameObject.GetComponent<Collider>().enabled = false;
        }
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
