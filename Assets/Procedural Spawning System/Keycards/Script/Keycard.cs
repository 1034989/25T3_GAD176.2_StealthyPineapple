using StealthyPineapple.Keycards;
using System;
using UnityEngine;

public class Keycard : KeycardParent
{
    [SerializeField]
    private bool isPickedUp = false;

    [SerializeField]
    public string keycardID;

    public GameObject Gate;

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
        DisableGate();
    }

    public void DisableGate()
    {
        Gate.SetActive(false);
        Debug.Log("the gate has disappeared!!");
    }

    
}
