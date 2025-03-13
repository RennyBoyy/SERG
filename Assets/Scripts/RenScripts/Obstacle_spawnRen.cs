using UnityEngine;

public class Obstacle_spawn : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;  // Array to hold asteroid obstacles
    public GameObject breakablePrefab;    // Breakable object prefab
    public GameObject collectiblePrefab;  // Collectible object prefab

    public GameObject player;  // Reference to the player
    public float spawnDistance = 30f;  // Distance ahead of the player
    public float spawnInterval = 5f;  // Time between spawns
    public float deleteDistance = 10f;  // Distance behind the player to delete obstacles
    private float lastSpawnZ = 0f;  // Track last spawn position

    public Transform[] spawnPoints;  // Array of spawn points

    void Start()
    {
        lastSpawnZ = player.transform.position.z + spawnDistance;
        InvokeRepeating("SpawnObjects", 1f, spawnInterval);
    }

    void SpawnObjects()
    {
        if (lastSpawnZ < player.transform.position.z + 30 || lastSpawnZ > player.transform.position.z + 200)
        {
            lastSpawnZ = player.transform.position.z + spawnDistance;
        }

        if (player == null || obstaclePrefabs.Length == 0 || breakablePrefab == null || collectiblePrefab == null) return;

        // Set spawn position ahead of the player
        float spawnZ = lastSpawnZ + spawnDistance;
        lastSpawnZ = spawnZ;

        bool[] usedPositions = new bool[spawnPoints.Length]; // Track used positions

        // Spawn obstacles (asteroids)
        int obstacleCount = Random.Range(1, 3); // Spawning 1 or 2 obstacles
        for (int i = 0; i < obstacleCount; i++)
        {
            int spawnIndex;
            do
            {
                spawnIndex = Random.Range(0, spawnPoints.Length);
            } while (usedPositions[spawnIndex]); // Ensure a new position

            usedPositions[spawnIndex] = true; // Mark position as used

            // Pick a random asteroid obstacle
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

            GameObject newObstacle = SpawnAtPosition(spawnIndex, spawnZ, obstaclePrefab);

            // Add DestroyObjects script to each obstacle
            DestroyObjects destroyScript = newObstacle.AddComponent<DestroyObjects>();
            destroyScript.deleteDistance = deleteDistance; // Optionally assign delete distance
        }

        // Try to spawn a breakable object (50% chance)
        if (Random.value < 0.5f)  // 50% chance for breakable item
        {
            int breakableIndex;
            do
            {
                breakableIndex = Random.Range(0, spawnPoints.Length);
            } while (usedPositions[breakableIndex]); // Ensure a new position

            usedPositions[breakableIndex] = true;
            GameObject newBreakable = SpawnAtPosition(breakableIndex, spawnZ, breakablePrefab);

            // Add DestroyObjects script for breakable object
            DestroyObjects destroyScript = newBreakable.AddComponent<DestroyObjects>();
            destroyScript.deleteDistance = deleteDistance;
        }

        // Try to spawn a collectible object (50% chance)
        if (Random.value < 0.5f)  // 50% chance for collectible item
        {
            int collectibleIndex;
            do
            {
                collectibleIndex = Random.Range(0, spawnPoints.Length);
            } while (usedPositions[collectibleIndex]); // Ensure a new position

            usedPositions[collectibleIndex] = true;
            GameObject newCollectible = SpawnAtPosition(collectibleIndex, spawnZ, collectiblePrefab);

            // Add DestroyObjects script for collectible object
            DestroyObjects destroyScript = newCollectible.AddComponent<DestroyObjects>();
            destroyScript.deleteDistance = deleteDistance;
        }
    }

    GameObject SpawnAtPosition(int spawnIndex, float zPosition, GameObject prefab)
    {
        Vector3 spawnPosition = spawnPoints[spawnIndex].position;
        spawnPosition.z = zPosition;
        return Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
}
