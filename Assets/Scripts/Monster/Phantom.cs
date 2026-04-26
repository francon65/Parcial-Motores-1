using UnityEngine;

public class Phantom : Monster
{
    [SerializeField] PlayerCore player;
    [SerializeField] float range;
    [SerializeField] GameObject projectile;
    [SerializeField] float fireRate;
    float lastTimeShot;
    void Start()
    {
        base.Start();
        lastTimeShot = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        Move(movementDirection);
        if(Vector3.Distance(player.transform.position, transform.position) <= range)
        {
            atack();
        }
        transform.LookAt(player.transform.position);
    }

    void atack()
    {
        if (lastTimeShot >= fireRate)
        {
            var Instance = Instantiate(projectile, transform.position + transform.forward, transform.rotation);
            lastTimeShot = 0f;
            animator.SetTrigger("Atack");
        }
        else lastTimeShot += Time.deltaTime;
        
        
    }
}
