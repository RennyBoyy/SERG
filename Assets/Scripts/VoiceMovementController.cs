using UnityEngine;

public class VoiceMovementController : MonoBehaviour
{
    private Vector3 currentPosition = Vector3.zero; // Start at (0,0,0)

    void Start()
    {
        transform.position = currentPosition; // Ensure player starts at (0,0,0)
    }

    public void MovePlayer(string direction)
    {
        Vector3 newPosition = currentPosition;

        switch (direction.ToLower())
        {
            case "up":
                newPosition.z += 1;
                break;
            case "down":
                newPosition.z -= 1;
                break;
            case "left":
                newPosition.x -= 1;
                break;
            case "right":
                newPosition.x += 1;
                break;
            default:
                Debug.Log("Invalid voice command");
                return;
        }

        // Ensure player stays within the 3x3 grid
        newPosition.x = Mathf.Clamp(newPosition.x, -1, 1);
        newPosition.z = Mathf.Clamp(newPosition.z, -1, 1);

        // Apply new position
        currentPosition = newPosition;
        transform.position = currentPosition;

        Debug.Log("Moved to: " + currentPosition);
    }
}
