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
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    
}
