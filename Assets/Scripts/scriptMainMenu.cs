using System;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptMainMenu : MonoBehaviour
{
    [Header("Panels")]
    public GameObject panelMenu;
    public GameObject panelSettings;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void StartGame()
    {
        bool isNew = false; // Eventually read a global variable (or preferably from a file) to detect a save file.
        if (isNew)
        {
            Debug.Log("Started new game");       
            SceneManager.LoadScene("sceneStoryStart"); 
        }
        else
        {
            Debug.Log("Attempting to load save");
            SceneManager.LoadScene("sceneMainGame");
        }
    }

    public void ToggleSettings()
    {
        if (panelMenu.activeSelf)
        {   
            panelMenu.SetActive(false);
            panelSettings.SetActive(true);
            Debug.Log("Entered Settings");
        }
        else
        {
            panelMenu.SetActive(true);
            panelSettings.SetActive(false);
            Debug.Log("Entered Main menu");
        }
    }

    public void ExitGame()
    {
        Debug.Log("Application Exit");
        Application.Quit();
    }
}
