using System;
using UnityEngine;

public class Monster : MonoBehaviour
{
    protected int damage;
    [SerializeField] float movementSpeed;
    protected bool activated;
    [SerializeField] protected Vector3 movementDirection;
    protected Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    protected virtual void Move(Vector3 movementVector)
    {
        Vector3 t = transform.InverseTransformDirection(movementVector);
        transform.position += t * (movementSpeed * Time.deltaTime);
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
