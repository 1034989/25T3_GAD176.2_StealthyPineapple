using UnityEngine;
namespace SteathyPineapple.MissionSystem
{ }
public class TargetObjectRotator : MonoBehaviour
{
   
    public float torqueAmount = 5f; // rotational force, didnt know torque was a thing, cool beans

    // direction of the rotation 
    public Vector3 rotationAxis = Vector3.up;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("TargetObject requires a Rigidbody component!"); // if i havent set up the rigidbody
        }
    }

    // This function is called when two non-trigger colliders make contact
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "canPickUp") // can the thrown object hit the target?
        {
            
            Vector3 hitDirection = collision.relativeVelocity.normalized; // what direction did it hit?

        
            rb.AddTorque(Vector3.Cross(hitDirection, rotationAxis) * torqueAmount, ForceMode.Impulse); // rotation method
            Debug.Log("Yeah baby thats called torque");
        }
    }
}
