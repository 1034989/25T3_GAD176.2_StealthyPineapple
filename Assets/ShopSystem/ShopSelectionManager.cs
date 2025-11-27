
using UnityEngine;
using SteathyPineapple.ShopSystem;
using SteathyPineapple.ItemSystem;
using NUnit.Framework;
using Unity.VisualScripting;

public class ShopSelectionManager : MonoBehaviour
{
    [SerializeField] private bool isSelected = false;
   
    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

      //if mouse isnt moveing then stop raycast till it moves?
        if (Physics.Raycast(ray,out hit)) 
        {
            if (hit.transform.tag == "ShopSelection" && !isSelected)
            {
                // this selects the script from the Item that player is looking at and sets it as the Selected Item this means that the information for the event that will be pulled will be from that object
                ItemSystem selectedItem = hit.transform.gameObject.GetComponent<ItemSystem>(); 
               
                Debug.Log("looking at: " + hit.transform.name);
                isSelected = true;

                ShopEvents.OnLookAtShopItem?.Invoke(selectedItem.itemName, selectedItem.itemDiscription, selectedItem.purchasePrice);  
            }
            if (hit.transform.tag != "ShopSelection")
            {
                isSelected = false;
                ShopEvents.OnCloseShop?.Invoke();
            }
        }  
    }
}
