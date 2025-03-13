using UnityEngine;
using UnityEngine.SceneManagement;

public class Back2MM : MonoBehaviour
{
    public void LoadMainMenu()
    {
        // Access AudioManager via its singleton instance
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.StopBackgroundMusic();
        }

        // Reset the time scale to normal in case it was paused
        Time.timeScale = 1.0f;

        // Load the MainMenu scene
        SceneManager.LoadScene("MainMenu");
    }
}
