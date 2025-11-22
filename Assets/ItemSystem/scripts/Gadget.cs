using SteathyPineapple.ItemSystem;
using UnityEngine;
using UnityEngine.WSA;

public abstract class Gadget : ItemSystem, IHoldable
{
    public override void UseItem()
    {
        GadgetAbility();
        StartCoroutine(StartCoolDown());
    }

    public abstract void GadgetAbility();
  
    public void Holdable()
    {
        // do i need to have it holdable on an object object?
        //allows player to hold gadgets when selected

    }
}
