using SteathyPineapple.InventorySystem;
using SteathyPineapple.ItemSystem;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
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
    

    [SerializeField] private int maxAmountOfItemsInStack;

    //== moreInfo==\\
    //check if its stackable
    // base Damage of weapons

    [Header("Text Mesh Pro")]
    [SerializeField] TextMeshProUGUI itemNameText;
    [SerializeField] TextMeshProUGUI stackAmountText;
    [SerializeField] TextMeshProUGUI itemInfoNameText;
    [SerializeField] TextMeshProUGUI itemInfoDescriptionText;

    [Header("selection")]
    public GameObject selectShader;
    public bool thisItemSelected;
    private InventoryManager inventoryManager;
    private void Start()
    {
      inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }
    public int AddItem(string itemName, int quantity, string itemDiscription, int maxQuantity)
    {
        //check to see if the slot is already full
        if (isFull)
        {
            return quantity;
        }
        //Update item Name
        nameOfItem = itemName;
        itemNameText.text = nameOfItem;
        itemNameText.gameObject.SetActive(true);
        descriptionOfItem = itemDiscription;

        //Update Quantity 
       
        stackAmount += quantity;
        Debug.Log(stackAmount);
        if (stackAmount >= maxQuantity)
        {
          
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
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
    }
    public void OnLeftClick()
    {

        if (thisItemSelected)
        {
            //inventoryManager.UseItem(); 
            //need to make it that the item can be used when clicked on
            stackAmount -= 1;
            stackAmountText.text = stackAmount.ToString();
            if (stackAmount <= 0)
            {
                EmptySlot();
                stackAmount = 0;
            }
        }
        else
        {
            inventoryManager.DeselectAllslots();
            selectShader.SetActive(true);
            thisItemSelected = true;
            itemInfoNameText.text = nameOfItem;
            itemInfoDescriptionText.SetText("Discription: " + descriptionOfItem);
        }
    }
   
    private void EmptySlot()
    {
        itemNameText.gameObject.SetActive(false);
        stackAmountText.gameObject.SetActive(false);

        itemInfoDescriptionText.text = "";
        itemInfoNameText.text = "";
        inventoryManager.DeselectAllslots();
        isFull = false;

    }
}
