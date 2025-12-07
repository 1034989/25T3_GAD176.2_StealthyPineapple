using UnityEngine;



public class CloseCombat : Weapon
{
    //when weapon hits Target deal damage to target    

    public override void Attack()
    {
        Debug.Log("stab: " + baseDamage);
    }
}
/// Dev note
/// this script is in place for others to expand on if they need, this can be branched out to other child classes if need
