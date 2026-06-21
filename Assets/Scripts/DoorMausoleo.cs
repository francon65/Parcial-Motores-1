using UnityEngine;

public class DoorMausoleo : MonoBehaviour, Iinteractable
{
    [SerializeField] string keyneeded;
    Animator animator;
    AudioSource source;
    public void Interact()
    {

        if (PlayerCore.instance.GetKey(keyneeded))
        {
            if(NoteManager.Instance.NotesGathered() == 3)
            {
                animator.SetBool("Open", true);
                gameObject.GetComponent<Collider>().enabled = false;
                source.Play();
            }
            
        }
        else { PlayerCore.instance.ShowText(); }
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();    
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
