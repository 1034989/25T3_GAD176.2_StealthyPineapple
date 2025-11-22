using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject inventoryMenu;
    private bool menuActivated;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            menuActivated = !menuActivated;
            inventoryMenu.SetActive(menuActivated);
        }
    }
}