using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    private Health playerHealth;
    [SerializeField] int maxhealth;
    private void Start()
    {
        playerHealth = new Health(maxhealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerHealth.TakeDamage(1);
        }
    }
}
