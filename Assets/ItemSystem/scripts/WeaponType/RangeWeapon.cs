using UnityEngine;


public class RangeWeapon : Weapon
{
    [SerializeField] private GameObject Ammo;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float timeAfterShot;
    [SerializeField] private float projectileVelocity;
    //shoots projectile



    public override void Attack()
    {
        Debug.Log("shoot: " + baseDamage);
        GameObject projectile = Instantiate(Ammo, spawnPoint.transform.position, transform.rotation) as GameObject;
        Projectile projectileScript = projectile.transform.gameObject.GetComponent<Projectile>();
        if (projectileScript != null)
        {
           projectileScript.damage = baseDamage;
            projectileScript.TestCallFromRangeWeapon(); 
        }

        projectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, projectileVelocity * 10)); //this allows the ammo to be propelled forward.

        Destroy(projectile, timeAfterShot); //if the gameobject isnt already destroyed from on trigger in the projectiles script it will destory them here after a set amount of time


    }
}
