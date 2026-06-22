using UnityEngine;
using UnityEngine.SceneManagement;
public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;

    public float currenSens { get; private set; } = 200;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    private void OnEnable()
    {
        PlayerCore.OnPlayerDied += Restart;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetSens(float val)
    {
        currenSens = val;
    }

    private void OnDisable()
    {
        PlayerCore.OnPlayerDied -= Restart;
        SceneManager.activeSceneChanged -= ChangeScene;
    }

   
    private void ChangeScene(Scene escenaAnterior, Scene escenaNueva)
    {
        PlayerCore.OnPlayerDied -= PlayerCore.instance.ResetPosition;

    }


    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(2);
        }
        
    }
}
