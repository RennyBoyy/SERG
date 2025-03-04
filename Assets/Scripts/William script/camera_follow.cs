using UnityEngine;

public class camera_follow : MonoBehaviour
{
    public Transform player; // Reference to the player
    public Vector3 offset = new Vector3(0, 3, -6); // Adjust the camera position
    public float smoothSpeed = 10000f; // Camera movement speed

    void LateUpdate()
    {
        if (player == null) return;

        // Desired position based on the player's movement
        Vector3 targetPosition = player.position + offset;

        // Smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

        // Keep the camera facing forward
        transform.LookAt(player.position + Vector3.forward * 5);
    }
}
