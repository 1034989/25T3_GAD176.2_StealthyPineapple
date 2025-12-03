using UnityEngine;

public class SecurityCamera : MonoBehaviour
{   
    public bool isDestroy = false; 
    private bool playerDetected = false;
    private Transform player; 

    public CameraData CameraData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, CameraData.turningCameraSpeed * Time.deltaTime, 0); //you spin me right round, baby, right round, like a record baby, right round
        if (playerDetected = true)
        {
            playerIsVisible();
        }
    }
    private void playerIsVisible()
    {
        RaycastHit hit;
        //Original position of camera, facing forward, making sure it hit something, camera range
        if (Physics.Raycast (transform.position, transform.forward, out hit, CameraData.cameraDetectionRange))
        {
            if (hit.transform == player) //confirm if its a player 
            {
                playerDetected = true;
                //add the event here to alert the enemy
                Debug.Log("Player have been detected, now alerting enemies");
            }
            else
            {
                playerDetected = false;
            }
        }
    }


}
