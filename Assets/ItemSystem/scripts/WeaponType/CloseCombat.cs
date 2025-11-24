using UnityEngine;



public class CloseCombat : Weapon
{
    //when weapon hits Target deal damage to target    

    public override void Attack()
    {
        Debug.Log("stab: " + baseDamage);
    }
}
