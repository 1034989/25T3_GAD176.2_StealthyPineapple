using System.Collections;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using SteathyPineapple.InventorySystem;
using UnityEngine.Rendering;
using UnityEditor.Experimental.GraphView;
using JetBrains.Annotations;
using UnityEditor;

namespace SteathyPineapple.ItemSystem
{
    public abstract class Item : MonoBehaviour
    {
        [Tooltip("info that is displayed in inventory and shop")]
        [Header("Display Info")]
        [SerializeField] protected string itemName;
        [TextArea(5, 10)] //min 5 lines, max 10 lines before scroll bar
        [SerializeField] private string itemDiscription;

       
        [Header("Value")]
        [SerializeField] private int buyingPrice;
        [SerializeField] private int sellingPrice;


        
        [Header("CoolDown Varibles")]
        [SerializeField] private bool isUsable = true;
        [SerializeField] private float coolDownTime;
        //[SerializeField]

        [Header("Stack Conditions")]
        public bool isStackable;
      //[HideInInspector]
        public int quantity; //since i dont want anyone to use this hide in Inspector does what it says
        public int maxQuantity;
        
        private void Start()
        {
            if (isStackable == false || maxQuantity < 1)
            {
                //item is not stackable
                maxQuantity = 1;
                //this sets the base item to be always cannot be stacked
            }
            
        }
        private void Update()
        {
            
           if(Input.GetKeyDown(KeyCode.Q) && isUsable == true)
            {
                UseItem();
            }
            
            if(Input.GetKeyDown(KeyCode.Space)) //will replace this with on collision and purchased
            {
                Test();
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

         private void Test() // this is to be added to the purchase script
         {
            InventoryManager inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();

            int leftOverItems = inventoryManager.AddItem(itemName, quantity, itemDiscription, maxQuantity);
                
                if (leftOverItems <= 0)
                {
                
                }
                else
                    quantity = leftOverItems;
            //if item is hit with raycast
            //hit object will be set to add to store when bought
         }
       

    }
}
