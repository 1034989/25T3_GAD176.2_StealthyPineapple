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
        [SerializeField] private float rotationSensitivity = 1f; // How sensitive the items rotation is
        [SerializeField] private GameObject heldObj; // Selected Object
        [SerializeField] private Rigidbody heldObjRb; // Selected Object Rigidbody
        [SerializeField] private bool canDrop = true; // boolean that makes sure the item isnt dropped or thrown when rotating it
        [SerializeField] private int LayerNumber; // Layer Index
        public float continuousAcceleration = 0f; // I could achieve acceleration by reducing and increasing drag in the inspector but that doesnt tick off my LO's, this F**ING does.
        
        void Start()
        {
            LayerNumber = LayerMask.NameToLayer("holdLayer"); // Helps make sure item doesn't clip
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E)) //Pick-up key
            {
                if (heldObj == null) //if not holding anything
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
                    StopClipping(); // IGNORE; THIS DOESNT GET USED
                    ThrowObject(); // Throw Object
                }
            }
        }

        void PickUpObject(GameObject pickUpObj)
        {
            // Checks for a rigidbody
            if (pickUpObj.GetComponent<Rigidbody>())
            {
                // object we are holding
                heldObj = pickUpObj;
                // adds rigidbbody
                heldObjRb = pickUpObj.GetComponent<Rigidbody>();
                // disables physics
                heldObjRb.isKinematic = true;

                // stop the object  going through wall (THIS FAILED BTW THANK YOU YOUTUBE)
                heldObjRb.collisionDetectionMode = CollisionDetectionMode.Continuous;

                // Set layer so it doesn't collide with player
                heldObj.layer = LayerNumber;
                //  ignore collisions between object and the player
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
            // Do NOT set rotation here, as RotateObject handles it. and the object bugs out for some reason??
        }

        void RotateObject() // NOT EVEN SURE IF THIS STILL WORKS
        {
            if (Input.GetKey(KeyCode.R))// R key is for manual rotate
            {
                canDrop = false;

                // rotation logic
                float mouseX = Input.GetAxis("Mouse X") * rotationSensitivity;
                float mouseY = Input.GetAxis("Mouse Y") * rotationSensitivity;

                // Spin left or right 
                Quaternion yawRotation = Quaternion.AngleAxis(-mouseX, heldObj.transform.up);

                // Tilt up or down 
                Quaternion pitchRotation = Quaternion.AngleAxis(-mouseY, heldObj.transform.right);

                /// so like, pitch and yaw are the rotational axis on the horizontal and veritical axis, isnt that amazing? truely something huh
                // Apply new rotation to existing rotation
                heldObj.transform.localRotation = yawRotation * pitchRotation * heldObj.transform.localRotation;
            }
            else
            {

                // Resets object orientation to match the camera/hold position, ensuring stability.
                heldObj.transform.rotation = holdPos.transform.rotation;

                canDrop = true;
            }
        }

        void ThrowObject()
        {
            

            
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false); // Re-enable collision between object and the player gameobject.
            // Reset object 
            heldObj.layer = 0;
            // physics engine 
            heldObjRb.isKinematic = false;
            // Detach the object
            heldObj.transform.parent = null;
            
            IThrowable throwableBehavior = heldObj.GetComponent<IThrowable>(); // Implentmenting OCP, not that i will use it

            if (throwableBehavior != null)
            {
               
                throwableBehavior.OnThrown(heldObjRb, transform.forward, throwForce); // throwing logic
            }
            else
            {
                heldObjRb.AddForce(transform.forward * throwForce, ForceMode.Impulse); // immediate velocity
            }
           
            if (continuousAcceleration > 0)
            {
                //constant forward acceleration 
                heldObjRb.AddForce(transform.forward * continuousAcceleration, ForceMode.Acceleration);
            }
            heldObj = null;
        }

        void StopClipping() // Ironically this function doesnt get used cause the tutorial i followed used an older vers of unity
        {
            if (heldObj == null) return;

            float clipRange = Vector3.Distance(heldObj.transform.position, transform.position);

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, clipRange))
            {
                heldObj.transform.position = hit.point - transform.forward * 0.2f;
            }
        }

        public interface IThrowable // un-used OCP example
        {
            void OnThrown(Rigidbody rb, Vector3 throwDirection, float throwForce); //Every throw must have this
        }
    }
}