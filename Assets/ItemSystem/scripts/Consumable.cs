using System.Threading;
using UnityEngine;
using TMPro;
using SteathyPineapple.ItemSystem;


public class Consumable : ItemSystem
{
    [Header("In Inventory")]
    [SerializeField] private int stackableMaxAmount;
    public int amountInInventory = 0;

    [Header("Text Info")]
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI amountLeftText;
    

   


    //when used decrease the amountInInventory

    private void Start()
    {
        InfoUIUpdate();
    }
    public override void UseItem()
    {
        if (amountInInventory > 0)
        {
          
            ConsumableAction();
            //decrease item count by 1
            amountInInventory--;
            InfoUIUpdate();
            StartCoroutine(StartCoolDown());
        }
        return;
    }

    /// <summary>
    /// specific actions that each child-Item of the consumable class can use
    /// </summary>
    public virtual void ConsumableAction()
    {
        Debug.Log("oops");
    }

    private void InfoUIUpdate()
    {
        itemNameText.SetText(itemName);
        amountLeftText.SetText("{0}", amountInInventory);
     
    }
}
