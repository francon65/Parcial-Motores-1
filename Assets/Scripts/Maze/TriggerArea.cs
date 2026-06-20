using System.Collections;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    [SerializeField] Chaser chaser;
    bool triggered = false;
    [SerializeField] GameObject door;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (triggered) { return; }
        if (other.CompareTag("Player"))
        {

        }
    }

    IEnumerator Activate()
    {
        door.SetActive(false);
        chaser.TriggerWakeUp();
        yield return null;
    }
}
