using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public enum State {Idle,Chasing,Patrolling,Screeching }
public  class Chaser : MonoBehaviour
{

    [SerializeField] protected Transform playerTransform;
    [SerializeField]State state;
    protected NavMeshAgent agent;
    Animator animator;

    [SerializeField] int visionConeAngle = 45;
    [SerializeField] float visionRange = 10;
    [SerializeField] float maxChasreRange = 20;
    //Animation Triggers
    [SerializeField] string walkTrig = "Walk";
    [SerializeField] string runTrig = "Run";
    [SerializeField] string screamTrig = "Scream";
    [SerializeField] string idleTrig = "Idle";

    [SerializeField] float patrolRadius = 15f;
    [SerializeField] float waitTime = 2f;
    private float patrolTimer;
    [SerializeField]bool canStopChasing;
    [SerializeField] bool Intercept;
    [SerializeField] private float leadDistance;

    [SerializeField]private bool canLookForPlayer;

    //AUDIO
    AudioSource audioSource;
    [SerializeField]AudioClip scream;
    //AUDIO
    [SerializeField] AudioClip[] footstepSounds;
    [SerializeField] AudioMixerGroup sfxGroup;
    public float timeBetweenSteps = 2f;
    
    private float stepTimer;
    protected  void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        if (playerTransform == null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null) playerTransform = player.transform;
        }
    }

    protected  void Update()
    {
        switch (state)
        {
            case State.Idle:
                Idle();
                break;
            case State.Chasing:
                Chasing();
                break;
            case State.Patrolling:
                Patrolling();
                break;
            case State.Screeching:
                Screeching();
                break;
        }

        
    }

    void Idle()
    {
        animator.SetTrigger(idleTrig);

        if (!canLookForPlayer) { return; }
        if (CanSeePlayer())
        {
            animator.ResetTrigger(idleTrig);   
            state = State.Screeching;
        }
    }

    protected  void Chasing()
    {
        animator.SetTrigger(runTrig);
        Vector3 _targetPoint;
        PlayRandomFootstep();
        if (Intercept)
        {
            
            if (agent.remainingDistance < leadDistance)
            {
                _targetPoint = playerTransform.position;
                agent.speed = 5;
            }
            else { _targetPoint = playerTransform.position + (playerTransform.forward * leadDistance); agent.speed = 7; }
            
        }
        else { _targetPoint = playerTransform.position; }
        agent.SetDestination(_targetPoint);

        if (Vector3.Distance(transform.position, playerTransform.position) >maxChasreRange && canStopChasing)
        {
            animator.ResetTrigger(runTrig);
            state = State.Idle;
        }
    }
    void Patrolling()
    {
        if (CanSeePlayer())
        {
            animator.ResetTrigger(walkTrig);
            state = State.Screeching;
            return;
        }

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            patrolTimer += Time.deltaTime;
            animator.SetTrigger(idleTrig);
            if (patrolTimer >= waitTime)
            {
                MoveToPoint();
                patrolTimer = 0f;
            }
        }
    }

    void Screeching()
    {
        agent.isStopped = true;
        animator.SetTrigger(screamTrig);
    }

    bool CanSeePlayer()
    {
        Vector3 directionToPlayer = playerTransform.position - transform.position;
        directionToPlayer.Normalize();
        float dotProduct = Vector3.Dot(transform.forward, directionToPlayer);
        float angle = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;
        if (angle < visionConeAngle && Vector3.Distance(transform.position,playerTransform.position)<=visionRange)
        {
            return true;
        }
        else return false;
    }

    public void TriggerWakeUp()
    {
        canLookForPlayer = true;
    }

    public void MoveToPoint()
    {
        animator.SetTrigger(walkTrig);
        Vector3 randomDirection = transform.position + (UnityEngine.Random.insideUnitSphere * patrolRadius);

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, patrolRadius, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }

    }

    void ScreechEnd()
    {
        Debug.Log("end");
        animator.ResetTrigger(screamTrig);
        agent.isStopped = false;
        state=State.Chasing;
    }

    void ScreechStart()
    {
        audioSource.PlayOneShot(scream);
    }

    public void SetState(State state)
    {
        this.state = state;
    }

    void PlayRandomFootstep()
    {
        
        
            stepTimer -= Time.deltaTime;
            if (stepTimer <= 0f)
            {
                int randomIndex = UnityEngine.Random.Range(0, footstepSounds.Length);
                AudioClip clip = footstepSounds[randomIndex];

                audioSource.pitch = UnityEngine.Random.Range(0.5f, .8f);
                audioSource.PlayOneShot(clip);
                stepTimer = timeBetweenSteps;
            }
        
        else
        {
            stepTimer = 0.1f;
        }
        if (footstepSounds.Length == 0) return;


    }
}
