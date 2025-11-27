using TMPro;
using UnityEngine;
using SteathyPineapple.ShopSystem;


public class ShopItemInfoDisplay : MonoBehaviour
{
    [Header("Conditions")]
    [Tooltip("can an item can be stacked in inventory")]
    [SerializeField] private bool isStackable;
    [Tooltip("the amount of items can be in a stack")]
    [SerializeField] private int stackableAmount;

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

    private void OpenShopUI(string itemName, string itemDiscription, int buyingPrice)
    {
        shopUiCanvas.SetActive(true);
        itemNameText.text = itemName;
        itemDiscriptionText.text = itemDiscription;
        itemPriceText.text = "" + buyingPrice;
         

        //Debug.Log("name: " + itemName);
        //Debug.Log("Discription: " + itemDiscription);
        //Debug.Log("Price: " + buyingPrice);
    }
    private void CloseShopUI()
    {
        // AG 27/11/2025 17:37 - add a null check here in case this gameobject does not have a reference to the shopUiCanvas (:
        // RA 27/11/2025 17:55 - issue was that script was added to object that was being toggled on and off.
        shopUiCanvas.SetActive(false);
        
    }
}

