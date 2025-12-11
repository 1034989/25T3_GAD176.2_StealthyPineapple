using UnityEngine;

public class KeycardSpawnerFrameWork : MonoBehaviour
{

    /// <summary>
    /// the reason as to why i wanted minimum and maximum keycards to spawn in a spawn point so that if other people were to use project as a framework 
    /// they can use this and edit it however they wished to spawn whatever they want
    /// i also left some instruction below the code
    /// </summary>

    // Array of possible spawn points (assign in Inspector)
    public Transform[] spawnPoints;

    // The keycard prefab to spawn (assign in Inspector)
    public GameObject keycardPrefab;

    public GameObject gateGameObject;

    // Minimum and maximum number of keycards to spawn
    public int minKeycards = 1;
    public int maxKeycards = 3;

    

    void Start()
    {
        SpawnKeycards();
    }

    void SpawnKeycards()
    {
        // this determines randomly how many keycards to spawn within the scene
        int keycardsToSpawn = Random.Range(minKeycards, maxKeycards + 1);

        for (int i = 0; i < keycardsToSpawn; i++)
        {
            // Picks a random spawn point in the scene
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[randomIndex];

            // this spawns the keycard at the chosen position and rotation
            GameObject newkeycard = Instantiate(keycardPrefab, spawnPoint.position, spawnPoint.rotation) as GameObject;
            newkeycard.GetComponent<Keycard>().Gate = gateGameObject;
        }
    }

    
    
    //How to Use
    //Create Spawn Points:
    //Add empty GameObjects in your scene where you want the keycards to possibly appear.
    //Name them clearly, e.g., KeycardSpawnPoint1, KeycardSpawnPoint2, etc.
    //Assign Spawn Points:
    //Attach the KeycardSpawner script to an empty GameObject in your scene.
    //Drag all spawn point GameObjects into the spawnPoints array in the Inspector.
    //Assign Keycard Prefab:
    //Create your keycard prefab and assign it to the keycardPrefab field.
    //Customize Spawn:
    //Adjust minKeycards and maxKeycards to control random spawn count.
    //Optionally, set a spawnDelay if you want the keycards to appear after a few seconds.
}
