using UnityEngine;
using TMPro;
using UnityEngine.UI;
using SteathyPineapple.InventorySystem;
using Unity.VisualScripting.ReorderableList;

public class ItemSlot : MonoBehaviour
{
    //==item data==\\
    
    public string nameOfItem;
    public int Quantity;
    //public Sprite itemSprite;
    public bool isFull;

    //== moreInfo==\\
    //check if its stackable
    // base Damage of weapons

    //==item slot==\\ 
    [SerializeField] TextMeshProUGUI itemNameText;


    public void AddItem(string itemName)
    {
        this.nameOfItem = itemName;
        isFull = true;

        itemNameText.text = nameOfItem;
        itemNameText.gameObject.SetActive(true);
    }
}
