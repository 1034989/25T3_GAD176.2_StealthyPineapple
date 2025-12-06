using SteathyPineapple.ItemSystem;
using UnityEngine;

public abstract class Weapon : Item
{
    [Header("Combat Info")]
    [SerializeField] protected float baseDamage;

    public override void UseItem()
    {
        Attack();
        StartCoroutine(StartCoolDown()); //starts a cooldown within the item script
    }

    public abstract void Attack(); //this get override by the weapons when they are used as they have thier own set attack style
}
