using UnityEngine;
using UnityEngine.UI;

public class SliderSetup : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public enum CanalAudio { Master, Ambient, SFX }

    [Header("Configuración del Slider")]
    public CanalAudio canalAControlar;

    void Start()
    {
        Slider slider = GetComponent<Slider>();


        slider.minValue = 0.0001f;
        slider.maxValue = 1.0f;

        if (AudioManager.instance != null)
        {

            slider.onValueChanged.RemoveAllListeners();


            switch (canalAControlar)
            {
                case CanalAudio.Master:
                    slider.value = AudioManager.instance.masterVolume;
                    slider.onValueChanged.AddListener(AudioManager.instance.SetVolumeMaster);
                    break;

                case CanalAudio.Ambient:
                    slider.value = AudioManager.instance.ambientVolume;
                    slider.onValueChanged.AddListener(AudioManager.instance.SetVolumeAmbient);
                    break;

                case CanalAudio.SFX:
                    slider.value = AudioManager.instance.sfxVolume;
                    slider.onValueChanged.AddListener(AudioManager.instance.SetVolumeSFX);
                    break;
            }

            
        }
    }
}
