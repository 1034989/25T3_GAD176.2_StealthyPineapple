using System.Collections;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using SteathyPineapple.InventorySystem;

namespace SteathyPineapple.ItemSystem
{
    public abstract class ItemSystem : MonoBehaviour
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


       private InventoryManager inventoryManager;
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

         private void Test()
         {
            if (inventoryManager == null)
            { 
                inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>(); 
            }
            inventoryManager.AddItem(itemName);
            
         }
    }
}
