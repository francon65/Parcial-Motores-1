using UnityEngine;

public class ChurchDoor : MonoBehaviour, Iinteractable
{
    public float rotationSpeed = 2f;

    private bool locked = false;
    private bool keepOpen = false;
    private Quaternion targetRotation;
    private Quaternion openRotation;
    [SerializeField] Chaser chaser;
    void Start()
    {
        targetRotation = Quaternion.Euler(transform.localEulerAngles.x, 0f, transform.localEulerAngles.z);
        openRotation = Quaternion.Euler(transform.localEulerAngles.x, 81f, transform.localEulerAngles.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (locked)
        {

            transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * rotationSpeed);


            if (Quaternion.Angle(transform.localRotation, targetRotation) < 0.1f)
            {
                transform.localRotation = targetRotation;
                locked = false;
                
            }
        }
        else if (keepOpen)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, openRotation, Time.deltaTime * rotationSpeed);
            chaser.TriggerWakeUp();
            if (Quaternion.Angle(transform.localRotation, openRotation) < 0.1f)
            {
                transform.localRotation = openRotation;
                keepOpen = false; 
            }
        }
    }

    public void IsLocked(bool b)
    {
        locked = b;    
    }

    public void Interact()
    {
        if (!locked)
        {
            keepOpen = true;
        }
    }
}
