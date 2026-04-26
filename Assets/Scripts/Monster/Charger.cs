using UnityEngine;

public class Charger : Monster
{
    [SerializeField] float timeAlive;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activated = false;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Move(movementDirection);
        if (activated)
        {
            timeAlive -= Time.deltaTime;
            if(timeAlive <= 0)
            {
                ToggleActivation(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("I GOT U");
            PlayerCore.instance.ResetPosition();
            ToggleActivation(false);
        }
    }

    
}
