using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using Keycards;

public class PlayerInventory : MonoBehaviour
{
    // The distance up to which the player can pick up keycards
    public float pickUpDistance = 3f;

    // LayerMask to filter only keycards
    public LayerMask keycardLayer;

       
    // Update is called once per frame
    void Update()
    {
        // Check if player presses the pickup key (E)
        if (Input.GetKeyDown(KeyCode.E))
        {
            AttemptPickup();
        }
    }

    void AttemptPickup()
    {
        // Create a ray from the center of the screen (camera forward)
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Draw debug ray for visualization in Scene view
        Debug.DrawRay(transform.position, transform.forward * pickUpDistance, Color.green, 1f);

        // Perform the raycast
        if (Physics.Raycast(ray, out hit, pickUpDistance, keycardLayer))
        {
            // Check if the hit object has a Keycard component
            Keycard keycard = hit.collider.GetComponent<Keycard>();
            if (keycard != null)
            {
                // Handle keycard pickup
                keycard.PickUp();
                Debug.Log("Picked up the keycard: " + keycard.name);
            }
        }
    }

}
