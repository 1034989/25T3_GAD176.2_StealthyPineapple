using UnityEngine;
using StealthyPineapple.Keycards;

public class GateSpawner : MonoBehaviour
{
    // Reference to the Gate prefab
    public GameObject gatePrefab;

    // Position where the gate will be spawned
    public Transform gateSpawnPoint;

    void Start()
    {
        SpawnGate();
        
    }

    // Function to instantiate the gate prefab
    private void SpawnGate()
    {
        if (gatePrefab != null && gateSpawnPoint != null)
        {
            Instantiate(gatePrefab, gateSpawnPoint.position, gateSpawnPoint.rotation);
            Debug.Log("Gate spawned successfully!");
        }
    }
}
