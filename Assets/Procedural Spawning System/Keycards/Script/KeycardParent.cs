using UnityEngine;


namespace Keycards
{
public class KeycardParent : MonoBehaviour
{
    public virtual void GateUnlock()
        {
            Debug.Log("Player a picked up a keycard!!");
        }
}

}
