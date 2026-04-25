using System;
using UnityEngine;

public class Monster : MonoBehaviour
{
    protected int damage;
    [SerializeField] float movementSpeed;
    bool activated;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void Move()
    {
        transform.position += transform.forward * (movementSpeed * Time.deltaTime);
    }

    
    protected void ToggleActivation(bool activation)
    {
        gameObject.SetActive(activation);
    }

    public void Activate()
    {
        if (activated) return;
        activated = true;
        gameObject.SetActive(true);

    }
}
