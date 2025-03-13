using UnityEngine;

public class controlsUpdated : MonoBehaviour
{
    public ShipMovement movement;
    private bool gyroEnabled;
    private Gyroscope gyro;
    public float moveThresholdX = 0.2f;
    public float moveThresholdY = 0.2f;
    public float InputDelay = 0.2f;
    public float NextInput = 0f;
    private Vector3 startPosition;
    private Vector3 baselineTilt;
    private Animator animator; // Animator reference

    void Start()
    {
        gyroEnabled = SystemInfo.supportsGyroscope;
        if (gyroEnabled)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            startPosition = transform.position;
        }

        // Find Animator on the Player GameObject
        GameObject player = GameObject.Find("Player"); // Ensure Player GameObject is named correctly
        if (player != null)
        {
            animator = player.GetComponent<Animator>();
        }
        else
        {
            Debug.LogError("Player GameObject not found! Check Hierarchy.");
        }
    }

    void Update()
    {
        if (animator == null)
        {
            Debug.LogError("Animator not found! Make sure Player has an Animator component.");
            return;
        }

        if (Time.time > NextInput)
        {
            Vector3 tilt = Input.acceleration - baselineTilt;

            if (tilt.x < -moveThresholdX) // Lean Left
            {
                movement.MoveLeft();
                animator.SetTrigger("LeanLeft");
                Debug.Log("LeanLeft triggered");
                NextInput = Time.time + InputDelay;
            }
            else if (tilt.x > moveThresholdX) // Lean Right
            {
                movement.MoveRight();
                animator.SetTrigger("LeanRight");
                Debug.Log("LeanRight triggered");
                NextInput = Time.time + InputDelay;
            }

            if (tilt.y > moveThresholdY) // Lean Up
            {
                movement.MoveDown();
                animator.SetTrigger("LeanUp");
                Debug.Log("LeanUp triggered");
                NextInput = Time.time + InputDelay;
            }
            else if (tilt.y < -moveThresholdY) // Lean Down
            {
                movement.MoveUp();
                animator.SetTrigger("LeanDown");
                Debug.Log("LeanDown triggered");
                NextInput = Time.time + InputDelay;
            }
        }

        // Keyboard Debug Controls (Optional)
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { movement.MoveLeft(); animator.SetTrigger("LeanLeft"); }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) { movement.MoveRight(); animator.SetTrigger("LeanRight"); }
        else if (Input.GetKeyDown(KeyCode.UpArrow)) { movement.MoveUp(); animator.SetTrigger("LeanUp"); }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) { movement.MoveDown(); animator.SetTrigger("LeanDown"); }
    }
}
