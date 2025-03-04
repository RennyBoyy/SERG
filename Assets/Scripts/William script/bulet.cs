using UnityEngine;

public class bulet : MonoBehaviour

{
    public float speed = 20f;
    public float destroyTime = 2f; // Destroy projectile after 2 seconds

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle")) 
        {
            Object.FindFirstObjectByType<Score>().AddScore(20); 

            Destroy(other.gameObject);
            Destroy(gameObject);

        }
    }
}
