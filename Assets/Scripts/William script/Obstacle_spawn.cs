using UnityEngine;

public class Obstacle_spawn : MonoBehaviour
{
    public GameObject obstaclePrefab;  // The obstacle prefab
    public Transform player;  // Reference to the player
    public float spawnDistance = 30f;  // Distance ahead of the player
    public float spawnInterval = 5f;  // Time between spawns
    public float deleteDistance = 10f;  // Distance behind the player to delete obstacles
    private float lastSpawnZ = 0f;  // Track last spawn position
    
    public Transform[] spawnPoints;  // Array of 9 spawn points (3x3 grid)

    void Start()
    {
        lastSpawnZ = player.position.z + spawnDistance;
        InvokeRepeating("SpawnObstacle", 1f, spawnInterval);
    }

    void SpawnObstacle()
    {
        if (lastSpawnZ < player.position.z + 30 || lastSpawnZ > player.position.z + 200){
            lastSpawnZ = player.position.z + spawnDistance;
        }
        if (player == null || obstaclePrefab == null) return;

        // Set spawn position ahead of the player
        float spawnZ = lastSpawnZ + spawnDistance;
        lastSpawnZ = spawnZ;


        // Decide how many obstacles to spawn (1 to 6)
        int obstacleCount = Random.Range(1, 7);

        bool[] usedPositions = new bool[spawnPoints.Length]; // Track used positions

        for (int i = 0; i < obstacleCount; i++)
        {
            int spawnIndex;
            do
            {
                spawnIndex = Random.Range(0, spawnPoints.Length);
            } while (usedPositions[spawnIndex]); // Ensure it picks a new position

            usedPositions[spawnIndex] = true; // Mark position as used
            GameObject newObstacle = SpawnAtPosition(spawnIndex, spawnZ);
            
            // Attach the cleanup script to the spawned obstacle
            newObstacle.AddComponent<ObstacleCleaner>().player = player;
            newObstacle.GetComponent<ObstacleCleaner>().deleteDistance = deleteDistance;
        }
    }

    GameObject SpawnAtPosition(int spawnIndex, float zPosition)
    {
        Vector3 spawnPosition = spawnPoints[spawnIndex].position;
        spawnPosition.z = zPosition;
        return Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}