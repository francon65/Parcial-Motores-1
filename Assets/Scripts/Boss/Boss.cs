using UnityEngine;
using System;
using System.Collections;

public class GhostBoss : MonoBehaviour
{
    
    [SerializeField]
    Transform player;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform firePoint;         

    

    [SerializeField] float moveSpeed = 3.0f;
    [SerializeField] float hoverSpeed = 2.0f;
    [SerializeField] float hoverHeight = 0.5f;
    [SerializeField] float killDistance = 1.8f;   

    

    [SerializeField] float timeBetweenShots = 3.0f;
    [SerializeField] float projectileSpeed = 8.0f;

    [SerializeField] ParticleSystem deathparticles;
    
    public static event Action OnPlayerCaught;
    public static event Action OnBossDefeated;

    private float shotTimer;
    private bool isPlayerCaught = false;
    private float startY;


    public float maxHealth = 100f;
    public float healthDecayRate = 5f; 
    private float currentHealth;
    void Start()
    {

        currentHealth = maxHealth;
        startY = transform.position.y;
        shotTimer = timeBetweenShots;

        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null) player = playerObj.transform;
        }
    }

    void Update()
    {
        if (isPlayerCaught || player == null) return;

        currentHealth -= healthDecayRate * Time.deltaTime;
        if (currentHealth <= 0)
        {
            BossDie();
            return;
        }

        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        
        Vector3 currentPos = transform.position;
        currentPos.y += Mathf.Sin(Time.time * hoverSpeed) * hoverHeight * Time.deltaTime;
        transform.position = currentPos;

        
        transform.LookAt(player.position);

        
        shotTimer -= Time.deltaTime;
        if (shotTimer <= 0f)
        {
            ShootProjectile();
            shotTimer = timeBetweenShots;
        }

        
        if (Vector3.Distance(transform.position, player.position) <= killDistance)
        {
            CatchPlayer();
        }
    }

    void ShootProjectile()
    {
        if (projectilePrefab == null || firePoint == null) return;

        
        GameObject proj = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = proj.GetComponent<Rigidbody>();

        if (rb != null)
        {
            
            Vector3 targetDir = (player.position - firePoint.position).normalized;
            rb.linearVelocity = targetDir * projectileSpeed;
        }
    }

    private void CatchPlayer()
    {
        isPlayerCaught = true;
        OnPlayerCaught?.Invoke();
    }

    public void FreezeBoss()
    {
        isPlayerCaught = true;
    }

    private void BossDie()
    {
        isPlayerCaught = true;
        

       StartCoroutine(BossDeath()); 
       

       
    }

    private IEnumerator BossDeath()
    {
        deathparticles.Play();
        yield return new WaitForSeconds(6);
        Destroy(gameObject);
        OnBossDefeated?.Invoke();
    }
}
