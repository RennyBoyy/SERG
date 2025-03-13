using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioClip mainMenuMusic;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu")
        {
            // Ensure background music restarts if returning to MainMenu
            PlayBackgroundMusic(mainMenuMusic);
        }
    }

    public void PlayBackgroundMusic(AudioClip musicClip)
    {
        if (musicClip != null && (backgroundMusic.clip != musicClip || !backgroundMusic.isPlaying))
        {
            backgroundMusic.clip = musicClip;
            backgroundMusic.Play();
        }
    }

    public void StopBackgroundMusic()
    {
        if (backgroundMusic.isPlaying)
        {
            backgroundMusic.Stop();
        }
    }
}
