using System;
using UnityEngine;
using UnityEngine.AI;

public enum State {Idle,Chasing,Patrolling,Screeching }
public class Chaser : MonoBehaviour
{

    [SerializeField] private Transform playerTransform;
    [SerializeField]State state;
    private NavMeshAgent agent;
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

    [SerializeField]private bool canLookForPlayer;

    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (playerTransform == null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null) playerTransform = player.transform;
        }
    }

    void Update()
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

    void Chasing()
    {
        animator.SetTrigger(runTrig);
        agent.SetDestination(playerTransform.position);
        if (Vector3.Distance(transform.position, playerTransform.position) >maxChasreRange)
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
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * patrolRadius;

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
}
