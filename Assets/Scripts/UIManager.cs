using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject mainPanel; // This panel includes the main UI/HUD. Like timers, health, etc.
    public GameObject pausePanel; // This panel includes your pause settings/buttons.

    public void PauseToggle()
    {
        if (pausePanel.activeSelf)
        {
            pausePanel.SetActive(false);
            mainPanel.SetActive(true);
            Time.timeScale = 1f;
        }
        else
        {
            pausePanel.SetActive(true);
            mainPanel.SetActive(false);
            Time.timeScale = 0f;
        }
    }
}
