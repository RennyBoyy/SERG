using UnityEngine;

public class CollectibleTrigger : MonoBehaviour
{
    [SerializeField] private int coinValue = 10; // Each coin = 10 Astros
    [SerializeField] private AudioClip collectSound; // Assign in Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // Play collection sound
        if (collectSound)
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
        }

        // Notify CoinSystem
        if (CoinSystem.Instance != null)
        {
            CoinSystem.Instance.AddCoins(coinValue);
        }
        else
        {
            Debug.LogError("CoinSystem instance not found!");
        }

        // Destroy coin after collection
        Destroy(gameObject);
    }
}
