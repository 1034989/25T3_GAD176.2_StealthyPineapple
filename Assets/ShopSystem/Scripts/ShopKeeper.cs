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
        if (player != null)//this prevents the game from crashing or freaking out if it doesnt have a player
        {
            ///since Square Magnitide is used i needed to create chase and stopDistance to balance this out as distancefromplayer is squared with magnitude
            ///this also means that i dont have to put in  "closeToPlayerDistance * closeToPlayerDistance" mutliple times
            float stopDistance = closeToPlayerDistance * closeToPlayerDistance;
            float chase = chaseDistance * chaseDistance;

            Vector3 directiontoPlayer = player.position - transform.position;
            float distanceFromPlayer = directiontoPlayer.sqrMagnitude;
            //unity document API recommends to use SqrMagnitude instead of Magnitude, as it is calculated much faster than Magnitude itself


            transform.LookAt(player.position); 
            ///issue with the shopkeeper rolling on the x-axis 
            ///update: made the shopkeeper a floating head as it will look down at the player utilising that issue wit the x-Axis
    
            if (distanceFromPlayer > stopDistance && shouldMove == true)
            {
                ///will move towards player if conditions are met.
                Vector3 moveTowardsPlayer = (player.transform.position - transform.position);
                shopkeeperRigidbody.MovePosition(transform.position + moveTowardsPlayer * movementSpeed * Time.fixedDeltaTime);
                if (distanceFromPlayer <= stopDistance + 1)
                {
                    shouldMove = false; //when the shopkeeper is in stop range it will stop until player is out of range
                }
            }
            else
                if (distanceFromPlayer > chase)
                shouldMove = true;
            //while shopKeeper is in range wait till player is too far away then move towards player
        }
    }
}
            ///dev Note 
            ///for some reason the shopkeeper will stop when the player is moving,
            ///while i do like this feature, and leaving it as is i am curious to how this happened