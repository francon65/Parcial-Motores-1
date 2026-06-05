using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSurvivalScene : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(2);
        }
    }
}
