using Cinemachine;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SequenceManager : MonoBehaviour
{
    
    [SerializeField] Animator animator;

    public static SequenceManager instance;

    
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else { Destroy(gameObject); }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    

    void TriggerRestart()
    {
        StartCoroutine(ReloadScene());
    }

    void TriggerVictory()
    {
        StartCoroutine(LoadMenu());
    }
    private IEnumerator ReloadScene()
    {
        animator.SetBool("FadeOut",true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator LoadMenu()
    {
        animator.SetBool("FadeOut", true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
