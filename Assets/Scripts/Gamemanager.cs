using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCursor();
        }
    }

    void ToggleCursor()
    {
        Cursor.visible = !Cursor.visible;
        if(Cursor.visible )
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
