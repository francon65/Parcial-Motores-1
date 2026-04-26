using UnityEngine;

public class MonsterActivationArea : MonoBehaviour
{
    [SerializeField] Monster monster;

    private void OnTriggerEnter(Collider other)
    {
        monster.Activate();
    }
}
