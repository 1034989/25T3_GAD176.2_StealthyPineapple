using UnityEngine;

namespace SteathyPineapple.ShopSystem
{
    public static class ShopEvents
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


        /// <summary>
        /// this event closes shop when called
        /// </summary>
        public delegate void ShopClose();
        public static ShopClose OnCloseShop;
    }
}
