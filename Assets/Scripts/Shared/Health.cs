using UnityEngine;

public class Health 
{
    private int maxHealth; 
    private int currentHealth;
    public Health(int _maxHealth) { currentHealth = maxHealth = _maxHealth; }
    public void TakeDamage(int amount)
    {
        if (currentHealth <= 0) return;

        currentHealth -= amount;

    }

    public int GetCurrenthealth()
    {
        return currentHealth;
    }

    public void Reseathealth()
    {
        currentHealth = maxHealth;
    }
}
