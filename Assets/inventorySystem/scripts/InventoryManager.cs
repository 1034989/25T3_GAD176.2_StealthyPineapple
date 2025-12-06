using Unity.VisualScripting;
using UnityEngine;
using SteathyPineapple.ItemSystem;

namespace SteathyPineapple.InventorySystem
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] private GameObject inventoryMenu;
         public bool menuActivated;
        public ItemSlot[] itemSlot;


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                menuActivated = !menuActivated;
                inventoryMenu.SetActive(menuActivated);
                
                if (menuActivated == true)
                {
                    Time.timeScale = 0.0f; //timescale slows down the game speed, is used for slowmotion, of if set to zero it freezes the game actions. (this doenst effect camera movement for some reason)
                    Cursor.lockState = CursorLockMode.None; //since the game is frozen it will make the cursor visible so the user can interact with the slots in the inventory
                    Cursor.visible = true;


                    Debug.Log("timeScale is: " + Time.timeScale + " this means the game is paused when in inventory"); //checking if the timescale worked when in inventorysystem
                }
                else
                {// this is just the reverse of the if statement above, it will hide the cursor set timescale back to normal speed and toggle the inventory canvas off
                    Time.timeScale = 1.0f;
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    Debug.Log("timeScale is: " + Time.timeScale + " this means the game is unpaused when in game");
                }
            }
        }
        //RA: this is checking for the string of itemslots are in the game, each time something is added to a slot it will move to the next slot script and apply the next item to it unless it already exists in a slot.
        public int AddItem(string itemName, int quantity, string itemDiscription,int maxQuantity, int purchasePrice)
        {
            for (int i = 0; i < itemSlot.Length; i++) // i is a set value that will change as items are added to inventory or removed, it will always check if the first slot is empty if it isnt then checks the next slot and so on
            {
                if (itemSlot[i].isFull == false && itemSlot[i].nameOfItem == itemName || itemSlot[i].stackAmount == 0) //checks if the set slot is full or if the same name is passed through. this allows for items to be stacked and lock slots off when full
                {
                    int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemDiscription, maxQuantity, purchasePrice);
                    if (leftOverItems > 0)
                    {
                        leftOverItems = AddItem(itemName, leftOverItems, itemDiscription, maxQuantity, purchasePrice);
                    } //this carrys the remaining amount over and it will apply to the next slot when needed. 
                    return leftOverItems;
                }
            }
            return quantity;
        }
        public void DeselectAllslots()
        {// this function disables the last all selected slots when a new slot is selected. i should of also have this activate when inventory closes so when it opens inventory again it doesnt carry over.
            for (int i = 0; i < itemSlot.Length; i++)
            {
                itemSlot[i].selectShader.SetActive(false);
                itemSlot[i].thisItemSelected = false;
            }
        }
    }
    
    
}