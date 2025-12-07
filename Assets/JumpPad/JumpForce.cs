using UnityEngine;

public class JumpForce : MonoBehaviour
{
    private float jumpPower = 100f; //how much power does the pad have

    public void OnTriggerEnter(Collider other) //remember to set it as trigger
    {
        Rigidbody rigidbody = other.GetComponent<Rigidbody>(); //Make sure the object have rigidbody in order to work

        if (rigidbody != null)
        {
            //addforce = direction times the jumppower, then forcemode impulse is to make the force instant or immediate boost
            rigidbody.AddForce(transform.up * jumpPower, ForceMode.Impulse);
        }
    }
}
