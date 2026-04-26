using TMPro;
using UnityEngine;

public class Uimanager : MonoBehaviour
{
    public static Uimanager Instance;
    [SerializeField] private TextMeshProUGUI noteCounterText;
    int noteCounter = 0;    
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else { Destroy(gameObject); }
        noteCounterText.text = $"Notas {noteCounter}/X";
        Notes.OnNotePickUp += UpdateNoteCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateNoteCount()
    {
        noteCounter++;
        noteCounterText.text = $"Notas {noteCounter}/X";
    }
}
