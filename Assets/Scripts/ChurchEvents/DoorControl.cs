using UnityEngine;

public class DoorControl : MonoBehaviour
{
    [SerializeField]ChurchDoor churchDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            churchDoor.IsLocked(true);
            gameObject.SetActive(false);
        }

    }
}
