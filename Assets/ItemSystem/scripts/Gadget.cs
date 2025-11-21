using SteathyPineapple.ItemSystem;
using UnityEngine;
using UnityEngine.WSA;

public class Gadget : ItemSystem, IHoldable
{
    public override void UseItem()
    {
        ActivateAbility();
        StartCoroutine(StartCoolDown());
    }

   protected virtual void ActivateAbility()
    {
        Debug.Log("error: NOT WORKING");
    }
    public void Holdable()
    {
        // do i need to have it holdable on an object object?
        //allows player to hold gadgets when selected

    }
}
