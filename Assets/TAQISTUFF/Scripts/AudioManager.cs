using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource backgroundMusic; // Keep this private

    void Awake()
    {
        // Check if an instance already exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make this object persistent across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy the duplicate object
        }
    }

    public void PlayBackgroundMusic(AudioClip musicClip)
    {
        if (backgroundMusic.clip != musicClip)
        {
            backgroundMusic.clip = musicClip;
            backgroundMusic.Play();
        }
    }

    public void StopBackgroundMusic()
    {
        backgroundMusic.Stop(); // Stop the music completely
    }

    // Method to access background music AudioSource (if needed in other scripts)
    public AudioSource GetBackgroundMusic()
    {
        return backgroundMusic;
    }
}
