using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameMusic : MonoBehaviour
{
    [SerializeField] private AudioClip gameMusic; // Assign the music clip for MainGameScene in the Inspector

    void Start()
    {
        // Play the background music for the main game scene
        AudioManager.Instance.PlayBackgroundMusic(gameMusic);
    }

    // Call this method when the game is over
    public void GameOver()
    {
        // Stop the background music when the game is over
        AudioManager.Instance.StopBackgroundMusic();
    }
}
