using System.Collections;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using SteathyPineapple.InventorySystem;
using UnityEngine.Rendering;
using UnityEditor.Experimental.GraphView;
using JetBrains.Annotations;
using UnityEditor;
using SteathyPineapple.ShopSystem;
using UnityEditor.Search;

namespace SteathyPineapple.ItemSystem
{
    public abstract class Item : MonoBehaviour
    {
        [Tooltip("info that is displayed in inventory and shop")]
        [Header("Display Info")]
        public string itemName;
        [TextArea(5, 10)] //min 5 lines, max 10 lines before scroll bar
        public string itemDiscription;

        [Header("Value")]
        public int purchasePrice;
        public int sellingPrice;

        [Header("CoolDown Varibles")]
        [SerializeField] private bool isUsable = true;
        [SerializeField] private float coolDownTime;
        //[SerializeField]

        [Header("Stack Conditions")]
        public bool isStackable;
        //[HideInInspector] 
        public int quantity = 1; //since i dont want anyone to use this, hideinInspector does the opposite of SF, but i still need it to be public to be accessed in other Scripts
        public int maxQuantity;

        [Header("Store Stock")]
        [SerializeField]private int maxStock;
        public int stockAmount;
        
        private InventoryManager inventoryManager;
        private void Start()
        {
            if (isStackable == false || maxQuantity < 1)
            {
                //item is not stackable
                maxQuantity = 1;
                //this sets the base item to be always cannot be stacked
            }
            if (inventoryManager == null)
            {
                inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
            }
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q) && isUsable == true && inventoryManager.menuActivated == false)
            {
                UseItem();
            }
            
            if(Input.GetKeyDown(KeyCode.P)) //will replace this with on collision and purchased
            {
               // Test();
            }
        }
        /// <summary>
        /// UseItem: overridable method since each child of this Class has a different type of "Use"
        /// </summary>
        public abstract void UseItem();
       
        /// <summary>
        /// StartCoolDown: timer/Countdown used when a item has been used, prevents items from being used rapidly.
        /// </summary>
       
        protected IEnumerator StartCoolDown()
        {
            Debug.Log("cooldownstart" + this.itemName);
            isUsable = false;
            float waitTime = coolDownTime;
            while(waitTime > 0 && isUsable == false)
            {
                waitTime -= Time.deltaTime;
                yield return null;
            }
            isUsable = true;
            yield break;
        }

         ////private void Test() // this is to be added to the purchase script
         //   //this will become on trigger for collectables
         //{
         //   InventoryManager inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();

         //   int leftOverItems = inventoryManager.AddItem(itemName, quantity, itemDiscription, maxQuantity);
                
         //       if (leftOverItems <= 0)
         //       {
                
         //       }
         //       else
         //           quantity = leftOverItems;
         //   //if item is hit with raycast
         //   //hit object will be set to add to store when bought
         //}
       

    }
}
