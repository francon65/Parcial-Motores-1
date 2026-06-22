using UnityEngine;

public class WoodDoor : MonoBehaviour
{
    AudioSource source;
    [SerializeField]AudioClip clip;
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    private void OnDisable()
    {
        if (!gameObject.scene.isLoaded) return;

        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
        }
    }
}
