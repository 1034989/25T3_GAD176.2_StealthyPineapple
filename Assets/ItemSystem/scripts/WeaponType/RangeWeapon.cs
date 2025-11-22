using UnityEngine;


public class RangeWeapon : Weapon
{
    [SerializeField] private GameObject Projectile;

    //shoots projectile

    [SerializeField] private float projectileVelocity;

    public override void Attack()
    {
        Debug.Log("shoot: " + baseDamage);
        //instantiate projectile prefab and fire it in forward motion



    }
}
