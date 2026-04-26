using UnityEngine;

public class PahntomProjectile : MonoBehaviour
{
    Rigidbody body;
    [SerializeField] float forceMultiplier;
    bool deltDamage;
    void Start()
    {
        deltDamage = false;
        body = GetComponent<Rigidbody>();
        body.AddForce(transform.forward*forceMultiplier);
        Invoke("End", 5f);
    }

    void End()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerCore.instance.ReciveDamage(1);
        }
    }

}
