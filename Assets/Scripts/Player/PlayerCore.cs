using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCore : MonoBehaviour
{
    

    List<string> KeyesCollected;

    public static PlayerCore instance;
    Vector3 initialPosition;

    PlayerMovement movement;

    [SerializeField] GameObject pause;
    [SerializeField] private Image staminaBar;
    [SerializeField] private TextMeshProUGUI MensajeTXT;
    public static event Action OnPlayerDied;

     void Awake()
    {
      instance = this;  
    }
    private void Start()
    {
        KeyesCollected = new List<string>();
        if (instance == null)
        {
            instance = this;
        }
        movement = GetComponent<PlayerMovement>();
        
        initialPosition = transform.position;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
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
        
        movement.DisableContrler(true);
    }

    

    void TogglePause()
    {
        pause.SetActive(!pause.activeSelf);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else Time.timeScale = 0;
        ToggleCursor();
    }

    void ToggleCursor()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else Cursor.lockState = CursorLockMode.Locked;

        if (Cursor.visible)
        {
            Cursor.visible = false;
        }
        else Cursor.visible = true;
    }

    public void SetStamina(float value)
    {
        staminaBar.fillAmount = value;
    }

    public void ShowText(string _faltante)
    {
        StartCoroutine(Show(_faltante));
    }

    private IEnumerator Show(string faltente)
    {
        MensajeTXT.text = $"No tienes {faltente}";
        MensajeTXT.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        MensajeTXT.gameObject.SetActive(false);
    }

    public void Cought()
    {
        OnPlayerDied?.Invoke();
    }
}
