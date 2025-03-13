using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeScene : MonoBehaviour
{
    public float delay = 2f; // Set delay time in seconds
    public AudioClip mainMenuMusic; // Declare the AudioClip for MainMenu music

    public void LoadScene(string sceneName)
    {
        // Ensure persistent objects reset (like AudioManager)
        if (sceneName == "MainMenu")
        {
            // Stop music if it's playing and restart MainMenu music
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.StopBackgroundMusic();
                if (mainMenuMusic != null)
                {
                    AudioManager.Instance.PlayBackgroundMusic(mainMenuMusic); // Play main menu music
                }
            }
        }

        // Start loading the scene with delay
        StartCoroutine(LoadSceneWithDelay(sceneName, delay));
    }

    // Coroutine to handle delayed scene load
    IEnumerator LoadSceneWithDelay(string sceneName, float delayTime)
    {
        yield return new WaitForSeconds(delayTime); // Wait for the specified delay
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single); // Load the new scene
    }
}
