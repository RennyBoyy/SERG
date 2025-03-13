using UnityEngine;

public class BreakableTrigger : MonoBehaviour
{
    [SerializeField] private GameObject brokenVersion; // Prefab for broken object
    [SerializeField] private AudioClip breakSound; // Sound effect for breaking
    [SerializeField] private AudioClip crashSound; // Sound effect for crashing

    private Collider obstacleCollider;
    private bool isBroken = false; // Track if the object is broken

    private void Start()
    {
        obstacleCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet") && !isBroken) // If hit by bullet and not broken
        {
            BreakObject();
        }
        else if (other.CompareTag("Player") && !isBroken) // If player hits before breaking
        {
            TriggerGameOver();
        }
    }

    private void BreakObject()
    {
        isBroken = true; // Mark as broken

        // Play break sound
        if (breakSound)
        {
            AudioSource.PlayClipAtPoint(breakSound, transform.position);
        }

        // Spawn broken version
        if (brokenVersion)
        {
            Instantiate(brokenVersion, transform.position, transform.rotation);
        }

        // Disable collider so the player can pass
        if (obstacleCollider)
        {
            obstacleCollider.enabled = false;
        }

        // Destroy the original object
        Destroy(gameObject);
    }

    private void TriggerGameOver()
    {
        // Play crash sound
        if (crashSound)
        {
            AudioSource.PlayClipAtPoint(crashSound, transform.position);
        }

        // Call Game Over UI
        GameManager.Instance.GameOver();
    }
}
