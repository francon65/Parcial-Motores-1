using UnityEngine;

public class KeyItem : Item
{
    [SerializeField] string keyName = "MainDoorKey";
    

    public override void Interact()
    {
        
        PlayerCore.instance.addkey(keyName);
        Destroy(gameObject);
    }
}
