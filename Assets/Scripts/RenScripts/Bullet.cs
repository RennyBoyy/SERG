using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float destroyTime = 2f; // Destroy projectile after 2 seconds
    public AudioClip shootSound; // Assign in Inspector

    private void Start()
    {
        // Play shoot sound when bullet is created
        if (shootSound)
        {
            AudioSource.PlayClipAtPoint(shootSound, transform.position);
        }

        Destroy(gameObject, destroyTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Breakable")) // Only destroy objects tagged as "Breakable"
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
