using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MMhandler : MonoBehaviour
{
    [SerializeField] private AudioClip mainMenuMusic;  // Music clip for the main menu
    [SerializeField] private Button playButton;        // Reference to Play button

    private void Start()
    {
        // Set the play button listener every time the scene loads
        playButton.onClick.AddListener(PlayGame);

        // Ensure the main menu music is playing if it's not already
        if (AudioManager.Instance != null && AudioManager.Instance.GetBackgroundMusic().clip != mainMenuMusic)
        {
            AudioManager.Instance.PlayBackgroundMusic(mainMenuMusic); // Play main menu music if it's not playing
        }
    }

    // Play the game
    public void PlayGame()
    {
        // Load the MainGameScene
        SceneManager.LoadScene("MainGameScene");

        // Start the background music for the game
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayBackgroundMusic(AudioManager.Instance.GetBackgroundMusic().clip); // Or pass the desired game music clip
        }

        // Ensure the game starts and Time.timeScale is reset
        Time.timeScale = 1f;
    }
}
