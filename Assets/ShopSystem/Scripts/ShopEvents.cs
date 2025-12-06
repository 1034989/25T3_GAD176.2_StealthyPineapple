using UnityEngine;

namespace SteathyPineapple.ShopSystem
{
    public static class ShopEvents
    {
        
        //if player is looking at an item in shop
        // then display UI
        // OnLookAtShopItem
        public delegate void ShopPopUp(string itemName, string itemDiscription, int purchasePrice, int quantity, int maxQuantity, int stockAmount);
        /// modifier to access
        ///item name
        ///item discription
        ///item BuyPrice
        ///quantity
        ///max amount
        public static ShopPopUp OnLookAtShopItem;


        /// <summary>
        /// this event closes shop when called
        /// </summary>
        public delegate void ShopClose();
        public static ShopClose OnCloseShop;

        public delegate void ShopKeeperInventory();
        public static ShopKeeperInventory OpenSellInventroy;

    }
}
