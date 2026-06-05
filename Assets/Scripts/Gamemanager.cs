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
    }
    private void Start()
    {
        PlayerCore.OnPlayerDied += PlayerCore.instance.ResetPosition;
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
        
        SceneManager.activeSceneChanged -= ChangeScene;
    }

   
    private void ChangeScene(Scene escenaAnterior, Scene escenaNueva)
    {
        PlayerCore.OnPlayerDied -= PlayerCore.instance.ResetPosition;

    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(2);
    }
}
