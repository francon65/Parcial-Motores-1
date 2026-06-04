using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI vida;


    private Health playerHealth;
    [SerializeField] int maxhealth;
    List<string> KeyesCollected;

    public static PlayerCore instance;
    Vector3 initialPosition;

    PlayerMovement movement;

    
    private void Start()
    {
        KeyesCollected = new List<string>();
        if (instance == null)
        {
            instance = this;
        }
        movement = GetComponent<PlayerMovement>();
        playerHealth = new Health(maxhealth);
        initialPosition = transform.position;
        UpdateText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerHealth.TakeDamage(1);
        }
        if (playerHealth.GetCurrenthealth() <= 0)
        {
            ResetPosition();
        }
    }

    public void addkey(string key)
    {
        KeyesCollected.Add(key);
    }
    public bool GetKey(string KeyName)
    {
        return KeyesCollected.Contains(KeyName);
    }

    public void ResetPosition()
    {
        movement.DisableContrler(false);
        transform.position = initialPosition;
        playerHealth.Reseathealth();
        movement.DisableContrler(true);
    }

    public void ReciveDamage(int damage)
    {
        playerHealth.TakeDamage(damage);
    }

    void UpdateText()
    {
        vida.text = playerHealth.GetCurrenthealth().ToString();
    }
}
