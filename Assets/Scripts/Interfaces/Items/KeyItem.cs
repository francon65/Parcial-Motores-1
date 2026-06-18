using UnityEngine;

public class KeyItem : Item
{
    [SerializeField] string keyName = "MainDoorKey";
    

    public override void Interact()
    {
        Debug.Log(PlayerCore.instance);
        PlayerCore.instance.addkey(keyName);
        Destroy(gameObject);
    }
}
