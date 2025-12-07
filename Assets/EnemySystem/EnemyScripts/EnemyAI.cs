using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer; // whatIsGround = default layer, whatIsPlayer = POI (placeholder) layer


    // PATROLING
    public Vector3 wayPoint;
    bool wayPointSet;
    public float wayPointRange;

    // ATTACKING
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;
    private float lifetime = 5.0f; // Private variable

    // STATES
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake() // called when the scene is loaded to find the player and agent
    {
        player = GameObject.Find("PlayerCapsule").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer); // Physics Detection Sphere Casting
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (!playerInSightRange && !playerInAttackRange) Patroling(); // if the player is not in sight or attack range the AI will patrol
        if (playerInSightRange && !playerInAttackRange) ChasePlayer(); // if the player is in sight range but not in attack range the AI will chase the player
        if (playerInAttackRange && playerInSightRange) AttackPlayer(); // if the player is in sight and attack range the AI will attack the player
    }

    private void Patroling() // Patroling function
    {
        if (!wayPointSet) searchWayPoint(); // if waypoint is false, call searchWayPoint() to find a new waypoint
        if (wayPointSet)
            agent.SetDestination(wayPoint);
        Vector3 distanceToWayPoint = transform.position - wayPoint; // Subtraction of vectors
        
        if (distanceToWayPoint.magnitude < 1f) // if the waypoint is reached, wayPointSet is set to false. Magnitude of vectors
            wayPointSet = false;
    }

    private void searchWayPoint() // searchWayPoint function
    {
        // Calculate random point in range
        float randomZ = Random.Range(-wayPointRange, wayPointRange);
        float randomX = Random.Range(-wayPointRange, wayPointRange);
        wayPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ); // Addition of vectors
        if (Physics.Raycast(wayPoint, -transform.up, 2f, whatIsGround))
            wayPointSet = true; // once a valid waypoint is found, wayPointSet is set to true
    }

    private void ChasePlayer() // ChasePlayer function
    {
        agent.SetDestination(player.position); // set the AI's destination to the player's position
    }

    private void AttackPlayer() // AttackPlayer function
    {
        // Makes sure AI doesn't move
        agent.SetDestination(transform.position);
        transform.LookAt(player); // makes the AI look at the player
        if (!alreadyAttacked) // if the AI hasn't already attacked then the AI will attack
        {
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse); // force to throw the projectile forward and up. Physics Movement Forces
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks); // stops the AI from attacking too fast
        }
    }

    private void ResetAttack() // ResetAttack function
    {
        alreadyAttacked = false; // resets the attack
    }

    private void OnDrawGizmosSelected() // Debugging
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    public void DestroyProjectile() // public function
    {
        if (projectile != null) // Null check
        {
            Destroy(projectile, lifetime);
        }
    }
}