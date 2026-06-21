using UnityEngine;
using System;

public class FirstTrigger : MonoBehaviour
{
    public static event Action Triggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Triggered?.Invoke();
        }
        
    }
}
