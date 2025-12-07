using UnityEngine;

public class SentryShoot : MonoBehaviour
{
    public SentryData SentryData;
    public PlayerHealth playerHealth;
    private float howClose = 10f;
    private float distancetoplayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 100f, Color.red, 1f, false); //position, forward, range, colour, duration, if blocking by an object

        if (Time.time >= SentryData.nextFireTime)
        {
            if(distancetoplayer <= howClose) //if it less than 10 meters it will shoot
            {
                SentryShot();
                SentryData.nextFireTime = Time.time + SentryData.fireRate; //there will a delay of shooting so it wont kill player instanty
            }
        }
    }

    public void SentryShot()
    {
        RaycastHit hit;

        //The original position of the sentry, the direction, checking if its hit something, attackdistance
        if (Physics.Raycast (transform.position, transform.forward, out hit, SentryData.shootRange))
        {
            if (hit.transform.tag == "Player")//ensure it hit player
            {
                Debug.Log("Sentry hit player" + playerHealth.playerHP); //saying what hit and name the gameobject  
                playerHealth.playerHP -= SentryData.sentryDamage; //this is fix this later when i get the player hp code
            }
        }
    }
}
