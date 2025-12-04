using UnityEngine;

public class Grab : MonoBehaviour
{
    bool isHolding = false;

    [SerializeField]
    float throwForce = 600f;
    [SerializeField]
    float maxDistance = 3f;
    float distance;

    TemporaryParent temporaryParent;
    Rigidbody rb;

    Vector3 objectPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        temporaryParent = TemporaryParent.Instance;
    }

    private void Update()
    {
        if (isHolding)
            Hold();
    }

    private void OnMouseDown() // Pickup function
    {
        if(temporaryParent != null)
        {
            isHolding = true;
            rb.useGravity = true;
            rb.detectCollisions = true;

            this.transform.SetParent(temporaryParent.transform);
        }
        else
        {
            Debug.Log("temporary parent item is not found in scene");
        }
    }

    private void OnMouseUp() // Drop function
    {

    }

    private void OnMouseExit() // Drop function 2
    {

    }

    private void Hold()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        if(Input.GetMouseButtonDown(1))
        {
            //throw function
        }
    }
}
