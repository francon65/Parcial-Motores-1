using UnityEngine;

public class ChacerIntercept : Chaser
{
    /*/
    [SerializeField] private float leadDistance;
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    //INTERCEPT
    protected override void Chasing()
    {
        Vector3 _targetPoint;
        if (Vector3.Distance(transform.position, playerTransform.position) < leadDistance + 3)
        {
            _targetPoint = playerTransform.position;
        }
        else { _targetPoint = playerTransform.position + (playerTransform.forward * leadDistance); }
        agent.SetDestination(_targetPoint);
    }
    /*/
}
