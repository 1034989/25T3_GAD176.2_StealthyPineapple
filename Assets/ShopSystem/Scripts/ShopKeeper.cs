using System.Net.NetworkInformation;
using Unity.Cinemachine;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    [Header("ShopKeeper Movement")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float closeToPlayerDistance;
    [SerializeField] private float chaseDistance;
    [SerializeField] private bool shouldMove = true;


    private Rigidbody shopkeeperRigidbody;
    private Transform player;

    private void Start()
    {
        shopkeeperRigidbody = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    } 

    private void Update()
    {
        if (player != null)
        {
            float stopDistance = closeToPlayerDistance * closeToPlayerDistance;
            float chase = chaseDistance * chaseDistance;
            Vector3 directiontoPlayer = player.position - transform.position;
            float distanceFromPlayer = directiontoPlayer.sqrMagnitude;


            transform.LookAt(player.position); //issue with the shopkeeper rolling on the x-axis 


            if (distanceFromPlayer > stopDistance && shouldMove == true)
            {
                Vector3 moveTowardsPlayer = (player.transform.position - transform.position);
                shopkeeperRigidbody.MovePosition(transform.position + moveTowardsPlayer * movementSpeed * Time.fixedDeltaTime);
                if (distanceFromPlayer <= stopDistance + 1)
                {
                    shouldMove = false;
                }
            }
            else
                if (distanceFromPlayer > chase)
                shouldMove = true;
            //while shopKeeper is in range wait till player is too far away then move towards player
        }
    }
}