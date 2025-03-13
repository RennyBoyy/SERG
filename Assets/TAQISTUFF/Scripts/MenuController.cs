using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;
    public GameObject scorePanel;
    public GameObject shopPanel;

    public void OpenSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void BackToMainMenu()
    {
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
        scorePanel.SetActive(false);
        shopPanel.SetActive(false);
    }
    public void OpenScore()
    {
        mainMenuPanel.SetActive(false);
        scorePanel.SetActive(true);
    }
    public void OpenShop()
    {
        mainMenuPanel.SetActive(false);
        shopPanel.SetActive(true);
    }
}
