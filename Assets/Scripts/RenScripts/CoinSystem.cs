using UnityEngine;
using TMPro; // Import for TextMeshPro

public class CoinSystem : MonoBehaviour
{
    public static CoinSystem Instance { get; private set; } // Singleton pattern

    [SerializeField] private TextMeshProUGUI coinText; // Assign in Inspector
    private int totalCoins = 0; // Start at 0

    private void Awake()
    {
        // Ensure only one instance exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCoins(int amount)
    {
        totalCoins += amount;
        coinText.text = "Astros: " + totalCoins; // Update UI
    }
}
