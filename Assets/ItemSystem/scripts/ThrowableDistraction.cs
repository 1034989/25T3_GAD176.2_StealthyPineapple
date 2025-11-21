using UnityEngine;
using SteathyPineapple.ItemSystem;
public class ThrowableDistraction : Consumable
{
    //can be hold by the player
    //can be trown
    //
    [Header("conditions")]
    [SerializeField] private bool canbounce;


    
    public override void ConsumableAction()
    {       
        //add type of force to object to be thrown in arc
        //can this object bounce?                         
        //if yes bounce set number of time before stopping (dont know what this if good for) 
        //if no: lands and causes distraction for enemy
    }
}
