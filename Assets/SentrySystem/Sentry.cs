using UnityEngine;

public class Sentry : MonoBehaviour
{
    private Transform player; //this is the player info
    private float howClose = 10f; //how close you can get to sentry before shooting 
    private bool isDestroy = false;
    private float distancetoplayer; //how far the player is to the sentry

    public SentryData SentryData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SentryData.currentHealth = SentryData.maxHealth; //Start with max health 
        player = GameObject.FindGameObjectWithTag("Player").transform; //Sentry will look for player 
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= SentryData.nextFireTime)
        {
            if(distancetoplayer <= howClose) //if it less than 5 meters it will shoot
            {
                Shoot();
                SentryData.nextFireTime = Time.time + SentryData.fireRate;
            }
        }
        
        distancetoplayer = Vector3.Distance(player.position, transform.position); //distance between the player and enemy (player distance, enemy distance)
        
        if (distancetoplayer >= SentryData.shootRange) //if its like more 10 meter then it will look at player
        {
            transform.LookAt(player); //face toward player
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        //The original position of the sentry, the direction, checking if its hit something, attackdistance
        if (Physics.Raycast (transform.position, transform.forward, out hit, SentryData.shootRange))
        {
            //playerHealth -= SentryData.sentryDamage; this is fix this later when i get the player hp code
            Debug.Log("Sentry hit player" + hit.collider.gameObject.name); //saying what hit and name the gameobject
        }
         Debug.DrawRay(transform.position, transform.forward * 100f, Color.red); //draw a line of the raycast 
    }

    private void DamageTaken() //sentry taken damaged somehow 
    {
        if (SentryData.currentHealth <= 0) //if sentry health below 0
        {
            Destroy(gameObject); // i cant read, i think its said destory something
            Debug.Log("Sentry had been Destroy");
        }
    }

    //This script is for sentry mechanics 
    //Such as finding player, shooting player if spotted,
}
