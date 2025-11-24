
using UnityEngine;
using SteathyPineapple.ShopSystem;
using SteathyPineapple.ItemSystem;
using NUnit.Framework;

public class ShopSelectionManager : MonoBehaviour
{
    [SerializeField] private bool isSelected = false;
    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit))
        {
            if (hit.transform.tag == "ShopSelection" && !isSelected)
            {
                print(hit.transform.name);
                isSelected = true;
            }
        }
    }   
}
