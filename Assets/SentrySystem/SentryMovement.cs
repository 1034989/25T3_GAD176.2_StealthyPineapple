    using UnityEngine;

public class SentryMovement : MonoBehaviour
{
    //Waypoint can change through inspector 
    //Can adjust position through the scenes 
    //Can add more depending on the developer //recommend just use empty gameobject
    public Transform wayPoint1; //location for the first point
    public Transform wayPoint2; //location for the second point

    private Transform sentryPosition; //Pretty obvious amirite

    public SentryData SentryData;

    void Start()
    {
        sentryPosition = wayPoint1; //position of the sentry to move to the first point
    }

    void Update() //movement for the sentry to move point 1 to 2 
    {
        //the sentry position = movetoward (change sentry position --> sentry current position --> movespeed)
        transform.position = Vector3.MoveTowards(transform.position, sentryPosition.position, SentryData.sentryMoveSpeed * Time.deltaTime);
        
        //If the sentry get close to point 1
        if (Vector3.Distance(transform.position, sentryPosition.position) < 0.5f)
        {
            if (sentryPosition == wayPoint1) //change waypoint if reach point 1, so change it to point 2
            {
                sentryPosition = wayPoint2;
            }
            else //stay on point 1 if didnt reach it yet
            {
                sentryPosition = wayPoint1;
            }
        }
    }

    //This script is make the sentry move to one point to other
}
