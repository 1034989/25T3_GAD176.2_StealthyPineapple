using Unity.VisualScripting;
using UnityEngine;
using SteathyPineapple.ItemSystem;

namespace SteathyPineapple.InventorySystem
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] private GameObject inventoryMenu;
        private bool menuActivated;
        public ItemSlot[] itemSlot;


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                menuActivated = !menuActivated;
                inventoryMenu.SetActive(menuActivated);
                //pause game
                //make mouse visible
            }
        }
        public int AddItem(string itemName, int quantity, string itemDiscription,int maxQuantity, int purchasePrice)
        {
            for (int i = 0; i < itemSlot.Length; i++)
            {
                if (itemSlot[i].isFull == false && itemSlot[i].nameOfItem == itemName || itemSlot[i].stackAmount == 0)
                {
                    int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemDiscription, maxQuantity, purchasePrice);
                    if (leftOverItems > 0)
                    {
                        leftOverItems = AddItem(itemName, leftOverItems, itemDiscription, maxQuantity, purchasePrice);
                    }
                    return leftOverItems;
                }
            }
            return quantity;
        }
        public void DeselectAllslots()
        {
            for (int i = 0; i < itemSlot.Length; i++)
            {
                itemSlot[i].selectShader.SetActive(false);
                itemSlot[i].thisItemSelected = false;
            }
        }
    }
    
    
}