using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SequenceManager : MonoBehaviour
{
    [SerializeField] GameObject boss;
    [SerializeField] Vector3 position = new Vector3(12, 6, -6);
    [SerializeField] ParticleSystem part;
    [SerializeField] Animator animator;

    public static SequenceManager instance; 
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else { Destroy(gameObject); }
            StartCoroutine(StartSequence());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        
        GhostBoss.OnPlayerCaught += TriggerRestart;
        GhostBoss.OnBossDefeated += TriggerVictory;
    }

 
    private void OnDisable()
    {
        
        GhostBoss.OnPlayerCaught -= TriggerRestart;
        GhostBoss.OnBossDefeated -= TriggerVictory;
    }

    public IEnumerator StartSequence()
    {
        part.Play();
        yield return new WaitForSeconds(5);
        Instantiate(boss,position,Quaternion.identity);
        part.Stop();
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
