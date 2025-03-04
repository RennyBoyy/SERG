using UnityEngine;

public class GyroControl : MonoBehaviour
{
    public float moveSpeed = 5f;  // Speed for horizontal & vertical movement
    public float forwardSpeed = 5f;  // Constant forward movement speed
    private bool gyroEnabled;
    private Gyroscope gyro;

    void Start()
    {
        // Check if gyroscope is available
        gyroEnabled = SystemInfo.supportsGyroscope;
        if (gyroEnabled)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
        }
    }

    void Update()
    {
        // Automatic forward movement
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        if (gyroEnabled)
        {
            float tiltX = gyro.rotationRateUnbiased.x; // Forward & Backward tilt
            float tiltY = gyro.rotationRateUnbiased.y; // Left & Right tilt

            // Apply movement based on gyroscope tilt
            float moveX = Mathf.Clamp(tiltY, -1f, 1f) * moveSpeed * Time.deltaTime;  // Left-Right movement
            float moveY = Mathf.Clamp(tiltX, -1f, 1f) * moveSpeed * Time.deltaTime;  // Up-Down movement

            transform.Translate(new Vector3(moveX, moveY, 0));
        }
    }
}
