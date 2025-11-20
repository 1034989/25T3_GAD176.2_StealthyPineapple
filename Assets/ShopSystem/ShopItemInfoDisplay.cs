using TMPro;
using UnityEngine;
using StealthyPineapple.ShopSystem;

public class ShopItemInfoDisplay : MonoBehaviour
{
    [Tooltip("Prices of items")]
    [Header("Pricing Values")]
    [SerializeField] private int buyingPrice;
    [SerializeField] private int sellingPrice;

    [Header("Conditions")]
    [Tooltip("can an item can be stacked in inventory")]
    [SerializeField]private bool isStackable;
    [Tooltip("the amount of items can be in a stack")]
    [SerializeField] private int stackableAmount;

    [Header("Item Info")]
    [TextArea(5, 10)] //min 5, max 10 lines in inspector before adding scrollbar
    [SerializeField] private string ItemName;
    [SerializeField] private string ItemInfo;


    private void Start()
    {
       
    }
}

