using UnityEngine;

public class Sentry : MonoBehaviour
{
    public Transform player; //this is the player info

    private float howClose = 10f; //how close you can get to sentry before shooting 
    private float distancetoplayer; //how far the player is to the sentry

    public SentryData SentryData;
    public PlayerHealth playerHealth; //just for testing

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SentryData.currentHealth = SentryData.maxHealth; //Start with max health 
        player = GameObject.FindGameObjectWithTag("Player").transform; //Sentry will look for player 
    }

    // Update is called once per frame
    void Update()
    {
        distancetoplayer = Vector3.Distance(player.position, transform.position); //distance between the player and enemy (player distance, enemy distance)
        
        if (distancetoplayer >= SentryData.shootRange) //if its like more 10 meter then it will look at player
        {
            transform.LookAt(player); //face toward player
        }
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
    //Such as finding player
}
