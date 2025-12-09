using UnityEngine;

public class KeycardMovement : MonoBehaviour
{
    public float rotationSpeed = 45f;
    public float floatHeight = 0.5f;
    public float floatSpeed = 1f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        
        // Defining a rotation axis 
        Vector3 axis = new Vector3(0, 1, 0);

        // this ensures the Keycard's unit length
        axis = axis.normalized; 

        // Rotating the Keycard
        transform.Rotate(axis, rotationSpeed * Time.deltaTime);

        
        // Created a normalized "up" vector
        Vector3 upDir = Vector3.up.normalized;

        // Scaling the "up" vector by a varying magnitude
        float offsetMagnitude = Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        transform.position = startPos + upDir * offsetMagnitude;
    }
}
