using UnityEngine;

public class controls : MonoBehaviour
{
    public movement movement;
    public float shootCooldown = 1f;
    private float nextShootTime = 0f;
    public Fire Fire;
    private bool gyroEnabled;
    private Gyroscope gyro;
    public float moveThresholdX = 0.2f;
    public float moveThresholdY = 0.2f;
    public float InputDelay = 0.2f;
    public float NextInput = 0f;
    private Vector3 startPosition;
    private Vector3 baselineTilt; 
    void Start()
    {
        gyroEnabled = SystemInfo.supportsGyroscope;
        if (gyroEnabled)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
        }
    }
    
    void SetBaselineTilt()
    {
        baselineTilt = Input.acceleration;
        Debug.Log("Baseline Tilt Set: " + baselineTilt);
    }


    void Update()
    {
        if (Input.touchCount > 0 && Time.time > nextShootTime)
        {
            Fire.Shoot();
            nextShootTime = Time.time + shootCooldown; 
        }

        if (Time.time > NextInput){
        Vector3 tilt = Input.acceleration ; 

        
        if (tilt.x < -moveThresholdX) //Left
        {
            movement.MoveLeft();
            NextInput = Time.time + InputDelay;
            tilt.x = 0;
            tilt.y = 0;
        }
        
        else if (tilt.x > moveThresholdX) // Right
        {
            movement.MoveRight();
            NextInput = Time.time + InputDelay; 
            tilt.x = 0;
            tilt.y = 0;
      
        }

        if (tilt.y > moveThresholdY) // Up
        {
            movement.MoveDown();
            NextInput = Time.time + InputDelay; 
            tilt.x = 0;
            tilt.y = 0;
  
        }
        else if (tilt.y < -moveThresholdY) // Down
        {
            movement.MoveUp();
            NextInput = Time.time + InputDelay;
            tilt.x = 0;
            tilt.y = 0;

        }
        }
        // if (Input.GetKeyDown(KeyCode.LeftArrow)) movement.MoveLeft();
        // else if (Input.GetKeyDown(KeyCode.RightArrow)) movement.MoveRight();
        // else if (Input.GetKeyDown(KeyCode.UpArrow)) movement.MoveUp();
        // else if (Input.GetKeyDown(KeyCode.DownArrow)) movement.MoveDown();
        if (Input.touchCount > 0 && Time.time > nextShootTime)
        {
            Fire.Shoot();
            nextShootTime = Time.time + shootCooldown; 
        }
    }



}


