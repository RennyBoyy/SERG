using UnityEngine;

public class movement : MonoBehaviour
{
    private CharacterController controller;
    public float forwardSpeed = 10f;
    private Vector3 direction;
    public float laneDistance = 4f; 
    private int currentLane = 1; 
    private int currentHeight = 1;
    public float resetZPosition = 1000f;  // Z position at which to reset
    public float resetOffset = 10f;  // Offset to keep smooth transitions
    public Transform environment;  // Parent object of all obstacles (optional)
    public float baseSpeed = 10f;  // Starting speed
    public float maxSpeed = 50f;  // Maximum speed
    public float speedIncreaseRate = 0.1f; // How much speed increases per second
    private float currentSpeed;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentSpeed = baseSpeed;
    }

    void Update()
    {
        // speed ramping
        currentSpeed += speedIncreaseRate * Time.deltaTime;
        currentSpeed = Mathf.Min(currentSpeed, maxSpeed);

        forwardSpeed = currentSpeed;
        // Move Forward
        direction.z = forwardSpeed;

        controller.Move(direction * Time.deltaTime);

        if (transform.position.z >= resetZPosition)
        {
            ResetPlayerPosition();
        }
        
    }
    public void MoveLeft()
    {
        if (currentLane > 0)
        {
            currentLane--;
            MoveToLane();
        }
    }

    public void MoveRight()
    {
        if (currentLane < 2)
        {
            currentLane++;
            MoveToLane();
        }
    }

    public void MoveUp()
    {
        if (currentHeight < 2)
        {
            currentHeight++;
            UpDown();
        }
    }

    public void MoveDown()
    {
        if (currentHeight > 0)
        {
            currentHeight--;
            UpDown();
        }
    }

    
    void MoveToLane()
    {
        Vector3 targetPosition = transform.position;
        targetPosition.x = (currentLane - 1) * laneDistance; // -1 = Left, 0 = Middle, 1 = Right
        StartCoroutine(SmoothLaneChange(targetPosition));
        // transform.position = targetPosition;
    }

    void UpDown()
    {
        Vector3 targetPosition = transform.position;
        targetPosition.y = (currentHeight - 1) * laneDistance; // -1 = down, 0 = Middle, 1 = up
        StartCoroutine(SmoothLaneChange(targetPosition));
        // transform.position = targetPosition;
    }
    

    System.Collections.IEnumerator SmoothLaneChange(Vector3 targetPos)
    {
        float elapsedTime = 0;
        float duration = 0.2f;
        Vector3 startPos = transform.position;

        while (elapsedTime < duration)
        {
            // Move Forward
            direction.z = forwardSpeed;
            controller.Move(direction * elapsedTime);
            
            transform.position = Vector3.Lerp(startPos, targetPos, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
    }

    void ResetPlayerPosition()
    {
        // Store current X and Y positions to avoid jumps
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, resetOffset);
        transform.position = newPosition;

        // Optional: Destroy all existing obstacles to prevent buildup
        if (environment != null)
        {
            foreach (Transform child in environment)
            {
                Destroy(child.gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle")) // If player collides with an obstacle
        {
            GameOver(); // Call the Game Over function
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over! You hit an obstacle.");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart the game
    }

}


