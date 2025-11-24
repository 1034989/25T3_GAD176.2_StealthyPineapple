using UnityEngine;
using SteathyPineapple.ItemSystem;
using UnityEngine.Analytics;

public class Potion : Consumable
{
    
   public override void ConsumableAction()
    {
        Debug.Log("i have drunk potion");
    }
}

