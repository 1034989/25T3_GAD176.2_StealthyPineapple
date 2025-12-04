using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public Transform PointofInterest;
    public float FollowRange;


    private NavMeshAgent agent;
    private float distanceToPOI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPOI = Vector3.Distance(transform.position, PointofInterest.position);
        if (distanceToPOI < FollowRange)
        {
            agent.SetDestination(PointofInterest.position);
        }
    }
}
