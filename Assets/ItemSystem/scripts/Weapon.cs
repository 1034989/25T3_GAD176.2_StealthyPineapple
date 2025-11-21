using SteathyPineapple.ItemSystem;
using UnityEngine;

public class Weapon : ItemSystem, IHoldable
{
    [Header("Combat Info")]
    [SerializeField] private float baseDamage;

    private void Update()
    {
        //on mouseClick use weapon


        //start cooldowntimer
        StartCoroutine(StartCoolDown());
    }

    public override void UseItem()
    {
        
    }

    public void Holdable()
    {
      //allows player to hold weapons when selected 
    }


}
