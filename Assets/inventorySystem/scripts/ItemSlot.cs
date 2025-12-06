using SteathyPineapple.InventorySystem;
using SteathyPineapple.ItemSystem;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEditor.Purchasing;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    //==item data==\\
    
    public string nameOfItem;
    public string descriptionOfItem;
    public int stackAmount;
    public bool isFull;
    private float sellingPrice; // this was never used as i didnt have a chance to set a sell system with the shopKeeper. as it wouldnt of met any of the LO
    

    [SerializeField] private int maxAmountOfItemsInStack;

    //== moreInfo==\\
    //check if its stackable
    // base Damage of weapons

    [Header("Text Mesh Pro")]
    [SerializeField] TextMeshProUGUI itemNameText;
    [SerializeField] TextMeshProUGUI stackAmountText;
    [SerializeField] TextMeshProUGUI itemInfoNameText;
    [SerializeField] TextMeshProUGUI itemInfoDescriptionText;
    [SerializeField] TextMeshProUGUI sellingPriceInformation;

    [Header("selection")]
    public GameObject selectShader;
    public bool thisItemSelected;
    private InventoryManager inventoryManager;
    private void Start()
    {
      inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }
    public int AddItem(string itemName, int quantity, string itemDiscription, int maxQuantity, int purchasePrice)
    { 
        //check to see if the slot is already full
        if (isFull)
        {//this will carrys over the remaining amount and will be processed back to inventory manager and find a new slot to be put into 
            return quantity;
        }
        //Update item Name
        nameOfItem = itemName;
        //display the name of item in the slots saying i have this item in inventory
        itemNameText.text = nameOfItem;
        //toggle the text on so its visible
        itemNameText.gameObject.SetActive(true);
        
        //this is just setting the game object information so when it is selected later it will display this information
        descriptionOfItem = itemDiscription;

        //Update Quantity amount
        stackAmount += quantity;
        Debug.Log(stackAmount);
        if (stackAmount >= maxQuantity)
        {
          //if the amount is full it will set the max amount, and toggle isFull which will lock off that slot till it is reduced or emptied
            stackAmountText.text = maxQuantity.ToString();
            stackAmountText.gameObject.SetActive(true);
            isFull = true;
            Debug.Log("full");

            //return the LEFTOVERS
            stackAmount = maxQuantity;
        }
        //update quantity text
        if (stackAmount >= 2)
        {
            stackAmountText.text = stackAmount.ToString();
            stackAmountText.gameObject.SetActive(true);
        }
        return 0;
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {//checks when the object is clicked with the left mouse input
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
    }
    public void OnLeftClick()
    {

        if (thisItemSelected) //if the slot is already selected use item
        {
            ///inventoryManager.UseItem(); 
            ///need to make it that the item can be used when clicked on
            ///when a slot is clicked it will decrease the value of the item, but will not use the items ability,
            ///this was not added as it wouldnt of met any LO and would of taken too much time to process
            stackAmount -= 1;
            stackAmountText.text = stackAmount.ToString();
            if (stackAmount <= 0)
            {// if the item is 0 then remove the item from the slot freeing it up so a new item can fill its place
                EmptySlot();
                stackAmount = 0;
            }
        }
        else
        {   //when panel is selected it will deselect the old panel and display the item information of the item
            inventoryManager.DeselectAllslots();
            selectShader.SetActive(true);
            thisItemSelected = true;
            itemInfoNameText.text = nameOfItem;
            itemInfoDescriptionText.SetText("Discription: " + descriptionOfItem);
        }
    }
   
    private void EmptySlot()
    {// if there is no more items in slot set all to default and make it empty
        itemNameText.gameObject.SetActive(false);
        stackAmountText.gameObject.SetActive(false);

        itemInfoDescriptionText.text = "";
        itemInfoNameText.text = "";
        inventoryManager.DeselectAllslots();
        isFull = false;

    }
}
