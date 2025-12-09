using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField]
    // Keycard required to open this gate
    public string requiredKeycardID;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if (inventory != null && inventory.HasKeycard(requiredKeycardID))
            {
                Debug.Log("Gate opened with keycard: " + requiredKeycardID);
                DisappearGate();
            }
            else
            {
                Debug.Log("You need keycard: " + requiredKeycardID);
            }
        }
    }


    void DisappearGate()
    {
        Destroy(gameObject);
        Debug.Log("Gate has disappeared!!");
    }

}
