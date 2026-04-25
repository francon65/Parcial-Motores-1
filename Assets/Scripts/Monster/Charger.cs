using UnityEngine;

public class Charger : Monster
{
    bool activated;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activated = false;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("I GOT U");
            ToggleActivation(false);
        }
    }

    
}
