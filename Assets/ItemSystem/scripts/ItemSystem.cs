using System.Collections;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using SteathyPineapple.ShopSystem;

namespace SteathyPineapple.ItemSystem
{
    public abstract class ItemSystem : MonoBehaviour
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

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q) && isUsable == true)
            {
                UseItem();
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
    }
}
