using NUnit.Framework;
using SteathyPineapple.InventorySystem;
using SteathyPineapple.ShopSystem;
using System.Collections;
using TMPro;
using UnityEngine;


public class ShopItemInfoDisplay : MonoBehaviour
{
    [Header("Stock")]
    [SerializeField] private int maxStock;
    private int leftInStock;
    private bool hasStock = true;
    [SerializeField] private TextMeshProUGUI clickToBuy;
    
    [Header("TextMeshProGUI")]
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemDiscriptionText;
    [SerializeField] private TextMeshProUGUI itemPriceText;

    [SerializeField] private GameObject shopUiCanvas;

    private void OnEnable()
    {
        ShopEvents.OnLookAtShopItem += OpenShopUI;
        ShopEvents.OnCloseShop += CloseShopUI;
    }
    private void OnDisable()
    {
        ShopEvents.OnLookAtShopItem -= OpenShopUI;
        ShopEvents.OnCloseShop -= CloseShopUI;
    }

    private void OpenShopUI(string itemName, string itemDiscription, int purchasePrice, int quantity, int maxQuantity, int stockAmount)
    {
        shopUiCanvas.SetActive(true);
        itemNameText.text = itemName;
        itemDiscriptionText.text = itemDiscription;
        itemPriceText.text = "" + purchasePrice;
        clickToBuy.text = "Click To buy " + itemName;
        StartCoroutine(BuyingItem(itemName, itemDiscription, purchasePrice, quantity, maxQuantity, maxStock));
        /// sending each of the params through the coroutine allows buyitem to use those values.
        
        ///test if when looking at items will display name and other information
        ///Debug.Log("name: " + itemName);
        ///Debug.Log("Discription: " + itemDiscription);
        ///Debug.Log("Price: " + buyingPrice);
    }
    
    IEnumerator BuyingItem( string itemName, string itemDiscription, int purchasePrice, int quantity,int maxQuantity, int stockAmount)
    {
        
        while(hasStock == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                ///waits till you click on the object to buy it this will tell the inventory manager to plus one to the inventory slots
                ///this will also be were i should do a check if player has enough currency, but this hasnt been implemented as of yet.
                Debug.Log("Bought " + itemName);
                InventoryManager inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
                int leftOverItems = inventoryManager.AddItem(itemName, quantity, itemDiscription, maxQuantity, purchasePrice);
                leftInStock -= quantity;
                //currency -= purchasePrice;
            }
            yield return null;
        }
        yield break; //even though it doenst ever reach this point since i havent added a stockamount or a method of toggling hasStock to false it will just keep on running until the closeShop event runs
    }
    private void CloseShopUI()
    {
        // AG 27/11/2025 17:37 - add a null check here in case this gameobject does not have a reference to the shopUiCanvas (:
        // RA 27/11/2025 17:55 - issue was that script was added to object that was being toggled on and off.
        shopUiCanvas.SetActive(false);
        StopAllCoroutines(); // since there is only one Coroutine it will stop the BuyingItem Ienumerator 
    }
}

