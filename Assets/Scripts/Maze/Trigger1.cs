using UnityEngine;

public class Trigger1 : MonoBehaviour
{
    [SerializeField] GameObject entity;
    Chaser chaser;
    bool triggered = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chaser = entity.GetComponent<Chaser>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!triggered)
        {
            entity.SetActive(true);
            chaser.TriggerWakeUp();
        }
        triggered = true;
    }
}
