using UnityEngine;

public class ObstacleCleaner : MonoBehaviour
{
    public Transform player; // Reference to the player
    public float deleteDistance = 10f; // Distance behind the player to delete obstacles

    void Update()
    {
        if ((player != null && transform.position.z < player.position.z - deleteDistance) || (player != null && transform.position.z > player.position.z + 300))
        {
            Destroy(gameObject); // Destroy obstacle when it's too far behind
        }
    }
}
