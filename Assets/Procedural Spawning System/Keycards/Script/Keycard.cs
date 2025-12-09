using Keycards;
using UnityEngine;

public class Keycard : KeycardParent
{
    // Unique ID or type for this keycard
    public string keycardID;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player collected the keycard
        if (other.CompareTag("Player"))
        {
            // Add keycard to player's inventory
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if (inventory != null)
            {
                inventory.AddKeycard(keycardID);
            }

            GateUnlock();
        }
    }

    public override void GateUnlock()
    {
        Debug.Log("Player has picked up" +  keycardID);
        // Destroy keycard object after pickup
        Destroy(gameObject);

    }
}
