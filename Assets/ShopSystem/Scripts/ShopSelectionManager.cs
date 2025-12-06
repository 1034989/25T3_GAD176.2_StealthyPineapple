
using UnityEngine;
using SteathyPineapple.ShopSystem;
using SteathyPineapple.ItemSystem;
using NUnit.Framework;
using Unity.VisualScripting;
using SteathyPineapple.InventorySystem;

public class ShopSelectionManager : MonoBehaviour
{
    [SerializeField] private bool isItemSelected = false;
    [SerializeField] private bool isShopkeeperSelected = false;
    private InventoryManager inventoryManager;

    private void Start()
    {//finds the game object wit hthe inventory manager this will be used to deactive the raycast when inventory is opened
       inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }
    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

      //if mouse isnt moveing then stop raycast till it moves?
        if (Physics.Raycast(ray,out hit) && !inventoryManager.menuActivated) 
        {
            if (hit.transform.tag == "ShopSelection" && !isItemSelected)
            {
                ///  this selects the script from the Item that player is looking at and sets it as the SelectedItem tag
                /// this means that the information for the event that will be pulled will be from that object
                Item selectedItem = hit.transform.gameObject.GetComponent<Item>(); 
               
                Debug.Log("looking at: " + hit.transform.name);
                isItemSelected = true; //isItemSelected basically prevents the raycast to constantly read the object, this means it will only happen once until the player looks away

                ShopEvents.OnLookAtShopItem?.Invoke(selectedItem.itemName,  selectedItem.itemDiscription, selectedItem.purchasePrice, selectedItem.quantity, selectedItem.maxQuantity, selectedItem.stockAmount); 
                //starts the OnLookAtShopItem event: sending the param values over into the event this will allow the UI to display what your looking at
            }
            if (hit.transform.tag == "Shopkeeper" && !isShopkeeperSelected)
            {
                //similarly to how the shop 
                isShopkeeperSelected = true; //isShopkeerSelected basically prevents the raycast to constantly read the object, this means it will only happen once until the player looks away
                Debug.Log("WHAT YOU STARING AT?");
                ShopEvents.OpenSellInventroy?.Invoke();  //since this event has NOT been fully set up it wont call anything until I have finished that script
                //what infromation do i need? 
                //when clicked on shopkeeper open inventory
                //pause game
                //sell prices from items

            }
            else
            if (hit.transform.tag != "ShopSelection" && isItemSelected || hit.transform.tag != "Shopkeeper" && isShopkeeperSelected)
            {//this basically deactivates all the UI and updates the bools so that it waits till the raycast hits a new object.
                isItemSelected = false;
                isShopkeeperSelected = false;
                ShopEvents.OnCloseShop?.Invoke();
                //starts the onCloseShop event: basically just closed the UI and disables the coroutine
            }
            
        }  
    }
}
