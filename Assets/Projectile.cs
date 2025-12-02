using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    public void TestCallFromRangeWeapon()
    {
        Debug.Log("this projectile will deal: "+ damage +" damage");
    }

    private void OnCollisionEnter(Collision hit)
    {
        //if(this projectile hits target) 
        Debug.Log("ive hit: " + hit.transform.name);
        Debug.Log("this projectile will deal: " + damage + " damage");

        //RA: this has been set up so that someone can start implimenting the damage to enemies
    }
}
