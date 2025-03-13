using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Button restartButton;
    [SerializeField] private AudioClip gameMusic; // Your music clip for the game

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        gameOverPanel.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);
        AudioManager.Instance.PlayBackgroundMusic(gameMusic); // Start playing background music at the beginning
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f; // Pause game
        AudioManager.Instance.StopBackgroundMusic(); // Stop music on Game Over
    }

    private void RestartGame()
    {
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
        AudioManager.Instance.PlayBackgroundMusic(gameMusic); // Restart music after restarting the game
    }
}
