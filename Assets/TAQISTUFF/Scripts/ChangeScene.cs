using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Required for Coroutines

public class ChangeScene : MonoBehaviour
{
    public float delay = 2f; // Set delay time in seconds

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneWithDelay(sceneName, delay));
    }

    IEnumerator LoadSceneWithDelay(string sceneName, float delayTime)
    {
        yield return new WaitForSeconds(delayTime); // Wait for the specified delay
        SceneManager.LoadScene(sceneName); // Load the new scene
    }
}
