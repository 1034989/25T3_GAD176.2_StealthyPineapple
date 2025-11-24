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
            }
        }
        public void AddItem(string itemName)
        {
            for (int i = 0; i < itemSlot.Length; i++)
            {
                if (itemSlot[i].isFull == false)
                {
                    itemSlot[i].AddItem(itemName);
                    return;
                }
            }
        }
    }
   
}