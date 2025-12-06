using SteathyPineapple.ItemSystem;
using UnityEngine;
using UnityEngine.WSA;

public abstract class Gadget : Item, IHoldable
{
    public override void UseItem()
    {
        GadgetAbility();
        StartCoroutine(StartCoolDown());
    }

    public abstract void GadgetAbility();
     //this get override by the Gadgets when they are used as they have thier own set Functionality and usage

public void Holdable()
    {
        // do i need to have it holdable on an object object?
        //allows player to hold gadgets when selected

    }
}
