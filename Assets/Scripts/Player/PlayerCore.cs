using System.Collections.Generic;
using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    private Health playerHealth;
    [SerializeField] int maxhealth;
    List<string> KeyesCollected;

    public static PlayerCore instance;
    private void Start()
    {
        KeyesCollected = new List<string>();
        if (instance == null)
        {
            instance = this;
        }
        playerHealth = new Health(maxhealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerHealth.TakeDamage(1);
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
}
