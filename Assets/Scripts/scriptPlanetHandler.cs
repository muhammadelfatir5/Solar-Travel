using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptPlanetHandler : MonoBehaviour
{
    [Header("Assign in level order (0 = Pluto (frick you, Neil Degrasse Tyson), 8 = Mercury)")]
    public GameObject[] PlanetLevels;
      /*
    Pluto
    Neptune
    Uranus
    Saturn
    Jupiter
    Mars
    Earth
    Venus
    Mercury
    */

    public int PlayerLevel = 9; // Obviously make this read from a save file.

    void Start()
    {
        for (int i = 0; i < PlayerLevel; i++)
        {
            if (PlanetLevels[i] == null)
            {
                Debug.LogWarning($"Planet at {i} is empty!");
                continue;
            }

            Transform lockTransform = PlanetLevels[i].transform.Find("lock");
            if (lockTransform != null)
            {
                GameObject lockObject = lockTransform.gameObject;
                lockObject.SetActive(false);
            }
            else
            {
                Debug.LogError($"Could not find lockObject under {PlanetLevels[i].name}");
            }
        }
    }

    public void SwitchToRocket()
    {
        SceneManager.LoadScene("sceneRocket");
    }
}
