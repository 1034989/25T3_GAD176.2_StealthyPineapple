using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<string> keycards = new List<string>();

    public void AddKeycard(string keycardID)
    {
        if (!keycards.Contains(keycardID))
        {
            keycards.Add(keycardID);
            Debug.Log("Collected Keycard: " + keycardID);
        }
    }

    public bool HasKeycard(string keycardID)
    {
        return keycards.Contains(keycardID);
    }
}
