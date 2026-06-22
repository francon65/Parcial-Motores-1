using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndFade : MonoBehaviour
{
    [SerializeField]GameObject fade;
    private void OnEnable()
    {
        Notes.OnNotePickUp += EndScreen;  
    }

    private void OnDisable()
    {
        Notes.OnNotePickUp -= EndScreen;
    }

    void EndScreen()
    {
        fade.SetActive(true);
        StartCoroutine(SendToMainMenu());

    }

    IEnumerator SendToMainMenu()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(0);
    } 
}
