using UnityEngine;
using TMPro;

public class DistanceTracker : MonoBehaviour
{
    public TextMeshProUGUI distanceText; // UI Text 
    public float distancePerSecond = 5f; // Distance increase
    private float totalDistance = 0f; // Total distance
    private bool isGameRunning = true;

    void Update()
    {
        if (isGameRunning)
        {
            // Increase distance over time based on Time.deltaTime
            totalDistance += distancePerSecond * Time.deltaTime;

            // Display total accumulated distance
            distanceText.text = "Distance: " + Mathf.FloorToInt(totalDistance) + "m";
        }
    }

    public void StopTracking()
    {
        isGameRunning = false; // Stop tracking when game over
    }
}
