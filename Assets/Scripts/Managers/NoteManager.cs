using TMPro;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager Instance;
    [SerializeField] private TextMeshProUGUI noteCounterText;
    int noteCounter = 0;    
    int totalNotes = 0;

    [SerializeField] GameObject NotesContainer;
    void Start()
    {
        totalNotes = NotesContainer.transform.childCount;
        if (Instance == null)
        {
            Instance = this;
        }
        else { Destroy(gameObject); }
        UpdateText();
        Notes.OnNotePickUp += UpdateNoteCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateNoteCount()
    {
        noteCounter++;
        UpdateText();
    }

    private void UpdateText()
    {
        noteCounterText.text = $"Notas {noteCounter}/{totalNotes}";
    }
}
