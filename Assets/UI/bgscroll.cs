using UnityEngine;
using UnityEngine.UI; // Add this for UI elements

public class InfiniteScrollingBackground : MonoBehaviour
{
    public RawImage backgroundImage; // Reference to the UI image
    public float scrollSpeed = 0.5f;

    void Update()
    {
        if (backgroundImage != null)
        {
            Rect uvRect = backgroundImage.uvRect;
            uvRect.x += scrollSpeed * Time.deltaTime;
            backgroundImage.uvRect = uvRect;
        }
        else
        {
            Debug.LogError("No RawImage assigned to InfiniteScrollingBackground script.");
        }
    }
}
