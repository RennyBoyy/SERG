using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    private Camera mainCamera;
    public float deleteDistance = 10f; // Add the delete distance here
    private float objectZPosition;

    void Start()
    {
        mainCamera = Camera.main;
        objectZPosition = transform.position.z;
    }

    void Update()
    {
        if (mainCamera == null) return;

        // Check if the object is behind the camera's view based on Z position
        if (transform.position.z < mainCamera.transform.position.z - deleteDistance)
        {
            Destroy(gameObject); // Destroy the object
        }
    }
}
