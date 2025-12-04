using UnityEngine;

public class TemporaryParent : MonoBehaviour
{
   public static TemporaryParent Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
