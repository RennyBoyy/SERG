using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuMusic : MonoBehaviour
{
    [SerializeField] private AudioClip mainMenuMusic; // Assign the music clip for MainMenu in the Inspector

    void Start()
    {
        // Play the background music when the MainMenu scene loads
        AudioManager.Instance.PlayBackgroundMusic(mainMenuMusic);
    }

    // Start the game and load the main game scene
    public void StartGame()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    // Quit the game
    public void ExitGame()
    {
        Application.Quit();
    }
}
