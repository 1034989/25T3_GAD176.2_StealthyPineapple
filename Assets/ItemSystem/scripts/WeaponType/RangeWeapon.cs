using UnityEngine;


public class RangeWeapon : Weapon
{
    [SerializeField] private GameObject Ammo;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float timeAfterShot;
    [SerializeField] private float projectileVelocity;
    //shoots projectile



    public override void Attack()
    {// spawns a new item base on the prefab projectile 
        Debug.Log("shoot: " + baseDamage);
        GameObject projectile = Instantiate(Ammo, spawnPoint.transform.position, transform.rotation) as GameObject;
        Projectile projectileScript = projectile.transform.gameObject.GetComponent<Projectile>();
        if (projectileScript != null)
        {//updates the Damage float value in the projectile script so it can carry the value and will apply damage when it hits target
           projectileScript.damage = baseDamage;
            projectileScript.TestCallFromRangeWeapon(); //a test function that will say in the console that the projectile has set amount of damage
        }

        projectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, projectileVelocity * 10)); //this allows the ammo to be propelled forward.

        Destroy(projectile, timeAfterShot); //if the gameobject isnt already destroyed from on trigger in the projectiles script it will destory them here after a set amount of time
    }
}
/// Dev note
/// this script is in place for others to expand on if they need, this can be branched out to other child classes if need