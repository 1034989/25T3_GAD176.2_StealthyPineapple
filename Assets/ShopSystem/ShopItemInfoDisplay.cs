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
    [SerializeField] TextMeshProUGUI itemNameText;
    [SerializeField] TextMeshProUGUI itemDiscriptionText;
    [SerializeField] TextMeshProUGUI itemPriceText;


    private void OnEnable()
    {
        ShopEvents.OnLookAtShopItem += OpenShopUI;
    }
    private void OnDisable()
    {
        ShopEvents.OnLookAtShopItem -= OpenShopUI;
    }

    private void OpenShopUI(string itemName, string itemDiscription, int buyingPrice)
    {
        itemNameText.text = itemName;
        itemDiscriptionText.text = itemDiscription;
        itemPriceText.text = "" + buyingPrice;

        //Debug.Log("name: " + itemName);
        //Debug.Log("Discription: " + itemDiscription);
        //Debug.Log("Price: " + buyingPrice);
    }
}

