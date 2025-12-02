using SteathyPineapple.ItemSystem;
using UnityEngine;

public abstract class Weapon : Item
{
    [Header("Combat Info")]
    [SerializeField] protected float baseDamage;

    public override void UseItem()
    {
        Attack();
        StartCoroutine(StartCoolDown());
    }

    public abstract void Attack();

}
