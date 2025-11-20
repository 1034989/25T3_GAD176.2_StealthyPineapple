using UnityEngine;

namespace StealthyPineapple.ShopSystem
{
    public class ShopEvents : MonoBehaviour
    {
        //if player is looking at an item in shop
        /// then display UI
        /// OnLookAtShopItem
      
        public delegate void ShopPopUp(string itemName, string itemDiscription, int buyingPrice);
        //access modifier
        //item name
        //item discription
        //item BuyPrice
        public static ShopPopUp OnLookAtShopItem;

        
        public delegate void SellingItems(string itemName, string itemDiscription, int sellingPrice);
        //item name
        //item discription
        //item BuyPrice
        public SellingItems OnSellingSelectedItem;
    }

}