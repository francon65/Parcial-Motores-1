using UnityEngine;

public class SecondTrigger : MonoBehaviour
{
    bool isActive=false;
    [SerializeField]GameObject Chaser;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame

    private void OnEnable()
    {
        FirstTrigger.Triggered += Activate;
    }
    private void OnDisable()
    {
        FirstTrigger.Triggered -= Activate;
    }
    void Update()
    {
        
    }

    void Activate()
    {
        isActive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isActive)
        {
            Chaser.SetActive(false);
        }
    }
}
