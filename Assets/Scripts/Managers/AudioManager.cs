using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
