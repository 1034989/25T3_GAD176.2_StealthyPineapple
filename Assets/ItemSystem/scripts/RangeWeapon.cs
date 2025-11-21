using Unity.VisualScripting;
using UnityEngine;

public class RangeWeapon : Weapon
{
    [SerializeField] private GameObject Projectile;

    //shoots projectile

    [SerializeField] private float projectileVelocity;
}
