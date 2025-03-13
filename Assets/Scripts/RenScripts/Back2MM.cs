using UnityEngine;
using UnityEngine.SceneManagement;

public class Back2MM : MonoBehaviour
{
    public AudioManager audioManager;

    public void LoadMainMenu()
    {
        // Stop the background music when transitioning to Main Menu
        if (audioManager != null)
        {
            audioManager.StopBackgroundMusic();
        }

        // Load the main menu scene
        SceneManager.LoadScene("MainMenu");
    }
}
