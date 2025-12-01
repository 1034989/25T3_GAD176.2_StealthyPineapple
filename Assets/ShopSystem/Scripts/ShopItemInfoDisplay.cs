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


    private void Start()
    {
    }

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
        
        //Debug.Log("name: " + itemName);
        //Debug.Log("Discription: " + itemDiscription);
        //Debug.Log("Price: " + buyingPrice);
    }
    
    IEnumerator BuyingItem( string itemName, string itemDiscription, int purchasePrice, int quantity,int maxQuantity, int stockAmount)
    {
        
        while(hasStock == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("Bought " + itemName);
                InventoryManager inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
                int leftOverItems = inventoryManager.AddItem(itemName, quantity, itemDiscription, maxQuantity, purchasePrice);
                leftInStock -= quantity;
                //currency -= purchasePrice;
            }
            yield return null;
        }
       
        yield break;
    }
    private void CloseShopUI()
    {
        // AG 27/11/2025 17:37 - add a null check here in case this gameobject does not have a reference to the shopUiCanvas (:
        // RA 27/11/2025 17:55 - issue was that script was added to object that was being toggled on and off.
        shopUiCanvas.SetActive(false);
        StopAllCoroutines();
    }
}

