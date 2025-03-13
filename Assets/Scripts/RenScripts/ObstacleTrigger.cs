using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip crashSound; // Sound when crashing

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // Play crash sound
        if (crashSound)
        {
            AudioSource.PlayClipAtPoint(crashSound, transform.position);
        }

        // Trigger Game Over UI
        GameManager.Instance.GameOver();
    }
}
