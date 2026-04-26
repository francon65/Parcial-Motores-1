using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    public Transform cam;
    [SerializeField] float speed;

    [SerializeField] float mouseSensitivity;
    float xRotation = 0f;
    float yRotation = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX=Input.GetAxisRaw("Mouse X") * Time.deltaTime * mouseSensitivity;
        float mouseY= Input.GetAxisRaw("Mouse Y") * Time.deltaTime * mouseSensitivity;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cam.localRotation = Quaternion.Euler(xRotation, 0, 0f);
        transform.rotation = Quaternion.Euler(0, yRotation, 0f);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        

        Vector3 move = transform.right * x + transform.forward * z;
        if (!controller.isGrounded)
        {
            move.y = -3;
        }
        controller.Move(move * speed * Time.deltaTime);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    public void DisableContrler(bool state)
    {
        controller.enabled = state;
    }
}
