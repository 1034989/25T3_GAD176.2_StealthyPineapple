using UnityEngine;
using System.Collections.Generic;
namespace SteathyPineapple.MissionSystem
{
    public class PickUpScript : MonoBehaviour
    {
        public GameObject player; // Player gameObject
        public Transform holdPos; // Position where the item is held
        public float throwForce = 500f; //How much force is applied to item when thrown
        public float pickUpRange = 5f; // Pick up radius
        private float rotationSensitivity = 1f; // How sensitive the items rotation is
        private GameObject heldObj; // Selected Object
        private Rigidbody heldObjRb; // Selected Object Rigidbody
        private bool canDrop = true; // boolean that makes sure the item isnt dropped or thrown when rotating it
        private int LayerNumber; // Layer Index

        void Start()
        {
            LayerNumber = LayerMask.NameToLayer("holdLayer"); // Helps make sure item doesn't clip

       
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E)) //Pick-up key
            {
                if (heldObj == null) //if  not holding anything
                {
                    
                    RaycastHit hit; // Is the player looking at anything?
                    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                    {
                        
                        if (hit.transform.gameObject.tag == "canPickUp") //Item needs to have this tag to be pickupable
                        {
                            PickUpObject(hit.transform.gameObject);
                        }
                    }
                }
                else
                {
                    if (canDrop == true) //If stop holding, drop
                    {
                        StopClipping(); // prevents object from clipping through walls
                        DropObject(); // Drops object
                    }
                }
            }
            if (heldObj != null) //if player is holding object
            {
                MoveObject(); //keep object position at holdPos
                RotateObject(); // Rotates object
                if (Input.GetKeyDown(KeyCode.Mouse0) && canDrop == true) //Mous0 = left mouse click this is used to throw
                {
                    StopClipping();
                    ThrowObject(); // Throw Object
                }

            }
        }
        void PickUpObject(GameObject pickUpObj)
        {
            if (pickUpObj.GetComponent<Rigidbody>()) // make sure the object has a RigidBody otherwise it isnt a solid object
            {
                heldObj = pickUpObj; //assign heldObj to the object that was hit by the raycast 
                heldObjRb = pickUpObj.GetComponent<Rigidbody>(); // give Rigidbody
                heldObjRb.isKinematic = true;
                heldObjRb.transform.parent = holdPos.transform; //parent object to holdposition
                heldObj.layer = LayerNumber; //change the object layer to the holdLayer
                                             //make sure object doesnt collide with player, it can cause weird bugs
                Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
            }
        }
        void DropObject()
        {
            //re-enable collision with player
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
            heldObj.layer = 0; //object assigned back to default layer
            heldObjRb.isKinematic = false;
            heldObj.transform.parent = null; //unparent object
            heldObj = null; //undefine game object
        }
        void MoveObject()
        {
            //keep object position the same as the holdPosition position
            heldObj.transform.position = holdPos.transform.position;
        }
        void RotateObject()
        {
            if (Input.GetKey(KeyCode.R))// R key is for rotate
            {
                canDrop = false; //make sure throwing can't occur during rotating

       

                float XaxisRotation = Input.GetAxis("Mouse X") * rotationSensitivity; // Rotate on X-Axis
                float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSensitivity; // Rotate on Y-Axis

                heldObj.transform.Rotate(Vector3.down, XaxisRotation); // Rotate on X-Axis
                heldObj.transform.Rotate(Vector3.right, YaxisRotation); // Rotate on Y-Axis
            }
            else
            {
                canDrop = true;
            }
        }
        void ThrowObject() // Literally the drop function but add force.
        {
            
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
            heldObj.layer = 0;
            heldObjRb.isKinematic = false;
            heldObj.transform.parent = null;
            heldObjRb.AddForce(transform.forward * throwForce);
            heldObj = null;
        }
        void StopClipping()
        {
            if (heldObj == null) return;

            float clipRange = Vector3.Distance(heldObj.transform.position, transform.position);

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, clipRange))
            {
                heldObj.transform.position = hit.point - transform.forward * 0.2f;
            }
        }
    }
}

