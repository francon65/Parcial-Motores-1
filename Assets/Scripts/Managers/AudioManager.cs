using UnityEngine;
using UnityEngine.Audio; 
using UnityEngine.UI;
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioMixer mainMixer;
    public string masterParam = "masterVolume";
    public string sfxParam = "sfxVolume";
    public string ambientParam = "ambienVolume";

    public float masterVolume { get; private set; } = 1.0f;
    public float sfxVolume { get; private set; } = 1.0f;
    public float ambientVolume { get; private set; } = 1.0f;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Asegúrate de tener esto para el cambio de escena
        }
        else Destroy(gameObject);
    }

    public void SetVolumeMaster(float sliderValue)
    {
        if (sliderValue == 0) sliderValue = 0.0001f;
        float dbValue = Mathf.Log10(sliderValue) * 20;
        masterVolume = sliderValue;

        mainMixer.SetFloat(masterParam, dbValue);
    }

    public void SetVolumeAmbient(float sliderValue)
    {
        if (sliderValue == 0) sliderValue = 0.0001f;
        float dbValue = Mathf.Log10(sliderValue) * 20;
        ambientVolume = sliderValue;

        
        mainMixer.SetFloat(ambientParam, dbValue);
    }

    public void SetVolumeSFX(float sliderValue)
    {
        if (sliderValue == 0) sliderValue = 0.0001f;
        float dbValue = Mathf.Log10(sliderValue) * 20;
        sfxVolume = sliderValue;

        
        mainMixer.SetFloat(sfxParam, dbValue);
    }

}
