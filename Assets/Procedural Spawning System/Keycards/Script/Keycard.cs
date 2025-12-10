using Keycards;
using UnityEngine;

public class Keycard : KeycardParent
{
    [SerializeField]
    private bool isPickedUp = false;

    [SerializeField]
    public string keycardID;

    // Method called when the keycard is picked up
    public void PickUp()
    {
        if (!isPickedUp)
        {
            isPickedUp = true;

            GateUnlock();

            
        }
    }


    public override void GateUnlock()
    {
        Debug.Log("Collected Keycard: " + keycardID);
        // Destroy keycard object after pickup
        Destroy(gameObject);

    }


}
