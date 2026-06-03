using UnityEngine;

public class CameraTurn : MonoBehaviour
{

    [SerializeField] private float speed = 5f;
    [SerializeField] Vector3 originalRotation;
    [SerializeField] Vector3 settingRotation;

    private float t = 0f;
    public  bool isRotated = false;
    void Start()
    {
        originalRotation = transform.eulerAngles;
        settingRotation = originalRotation + new Vector3(0, 90f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isRotated)
        {
            t = Mathf.MoveTowards(t, 1f, speed * Time.deltaTime);
        }
        else
        {
            t = Mathf.MoveTowards(t, 0f, speed * Time.deltaTime);
        }
        transform.eulerAngles = Vector3.Lerp(originalRotation, settingRotation, t);
    }

    public void ToggleRotation()
    {
        isRotated = !isRotated;
    }
}
