using UnityEngine;
using System;
public class Notes : Item
{
    public static event Action OnNotePickUp;
    public override void Interact()
    {
        OnNotePickUp?.Invoke();
        gameObject.SetActive(false);
    }
}
