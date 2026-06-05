using System;
using UnityEngine;
using UnityEngine.Audio;
[RequireComponent(typeof(AudioSource))]
public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    public Transform cam;
    [SerializeField] float speed;
    //FP CAM
    [SerializeField] float mouseSensitivity;
    float xRotation = 0f;
    float yRotation = 0f;
    //CORRER
    [SerializeField] float sprintSpeedMultiplier = 1.5f;
    [SerializeField] float maxStamina = 100f;
    [SerializeField] float drainRate = 25f;       
    [SerializeField] float regenRate = 15f;       
    [SerializeField] float regenDelay = 1f;

    float currentStamina;
    float regenTimer;
    bool isExhausted;

    //AUDIO
    [SerializeField] AudioClip[] footstepSounds;
    [SerializeField] AudioMixerGroup sfxGroup;    
    public float timeBetweenSteps = 0.7f;
    private AudioSource audioSource;
    private float stepTimer;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        controller = GetComponent<CharacterController>();
        currentStamina = maxStamina;
        audioSource = GetComponent<AudioSource>();
        stepTimer = timeBetweenSteps;

        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0f;
        if (sfxGroup != null)
        {
            audioSource.outputAudioMixerGroup = sfxGroup;
        }

        mouseSensitivity = Gamemanager.instance.currenSens;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX=Input.GetAxisRaw("Mouse X") * Time.deltaTime * mouseSensitivity;
        float mouseY= Input.GetAxisRaw("Mouse Y") * Time.deltaTime * mouseSensitivity;
        bool isMoving = Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;
        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cam.localRotation = Quaternion.Euler(xRotation, 0, 0f);
        transform.rotation = Quaternion.Euler(0, yRotation, 0f);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        float currentSpeed = speed;
        if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0 && !isExhausted)
        {
            currentSpeed = speed * sprintSpeedMultiplier;
            currentStamina -= drainRate * Time.deltaTime;
            regenTimer = 0f;

            if (currentStamina <= 0f)
            {
                currentStamina = 0f;
                isExhausted = true; 
            }
        }
        else
        {
            if (regenTimer < regenDelay)
            {
                regenTimer += Time.deltaTime;
            }
            else
            {
                currentStamina += regenRate * Time.deltaTime;
                if (currentStamina >= maxStamina)
                {
                    currentStamina = maxStamina;
                }
                if (isExhausted && currentStamina >= (maxStamina * 0.2f))
                {
                    isExhausted = false;
                }
            }
        }

        PlayRandomFootstep(isMoving);

        Vector3 move = transform.right * x + transform.forward * z;
        if (!controller.isGrounded)
        {
            move.y = -3;
        }
        controller.Move(move * currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    public void DisableContrler(bool state)
    {
        controller.enabled = state;
    }

    void PlayRandomFootstep(bool isWalking)
    {
        if (isWalking)
        {
            stepTimer -= Time.deltaTime;
            if (stepTimer <= 0f)
            {
                int randomIndex = UnityEngine.Random.Range(0, footstepSounds.Length);
                AudioClip clip = footstepSounds[randomIndex];

                audioSource.pitch = UnityEngine.Random.Range(0.85f, 1.15f);
                audioSource.PlayOneShot(clip);
                stepTimer = timeBetweenSteps;
            }
        }
        else
        {
            stepTimer = 0.1f;
        }
        if (footstepSounds.Length == 0) return;

        
    }

    public void ChangeSensitivity(float sliderValue)
    {
        mouseSensitivity = sliderValue;
        Gamemanager.instance.SetSens(mouseSensitivity);
    }
}
