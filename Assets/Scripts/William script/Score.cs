using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // UI Text for displaying score
    public float scoreMultiplier = 1f; // Adjust score rate
    private float score = 0f;
    private bool isGameRunning = true;

    void Update()
    {
        if (isGameRunning)
        {
            // Increase score based on time
            score += Time.deltaTime * scoreMultiplier;
            scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
        }
    }

    public void AddScore(int amount)
    {
        score += amount; // Extra score for collecting items or destroying obstacles
    }

    public void StopScoring()
    {
        isGameRunning = false; // Stop score when game over
    }
}
