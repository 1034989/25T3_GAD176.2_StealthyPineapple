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
/// Dev note
/// this script is in place for others to expand on if they need, this can be branched out to other child classes if need
///for example Healing, Strenght, invisiblity ect. 