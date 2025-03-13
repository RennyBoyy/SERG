using UnityEngine;

public class MMhandler : MonoBehaviour
{
    [SerializeField] private AudioClip mainMenuMusic; // Assign this in the Inspector

    void Start()
    {
        // Ensure AudioManager exists and plays the correct background music
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayBackgroundMusic(mainMenuMusic);
        }
        else
        {
            Debug.LogWarning("AudioManager instance not found!");
        }
    }
}
