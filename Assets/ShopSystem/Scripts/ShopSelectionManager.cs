
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
    {
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
                // this selects the script from the Item that player is looking at and sets it as the Selected Item this means that the information for the event that will be pulled will be from that object
                Item selectedItem = hit.transform.gameObject.GetComponent<Item>(); 
               
                Debug.Log("looking at: " + hit.transform.name);
                isItemSelected = true;

                ShopEvents.OnLookAtShopItem?.Invoke(selectedItem.itemName,  selectedItem.itemDiscription, selectedItem.purchasePrice, selectedItem.quantity, selectedItem.maxQuantity, selectedItem.stockAmount);  
            }
            if (hit.transform.tag == "Shopkeeper" && !isShopkeeperSelected)
            {
                
                isShopkeeperSelected = true;
                Debug.Log("WHAT YOU STARING AT?");
                ShopEvents.OpenSellInventroy?.Invoke(); 
                //what infromation do i need? 
                //when clicked on shopkeeper open inventory
                //pause game
                //sell prices from items

            }
            else
            if (hit.transform.tag != "ShopSelection" && isItemSelected || hit.transform.tag != "Shopkeeper" && isShopkeeperSelected)
            {

                isItemSelected = false;
                isShopkeeperSelected = false;
                ShopEvents.OnCloseShop?.Invoke();
            }
            
        }  
    }
}
