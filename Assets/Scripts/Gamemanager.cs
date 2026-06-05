using UnityEngine;

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
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetSens(float val)
    {
        currenSens = val;
    }
    
}
