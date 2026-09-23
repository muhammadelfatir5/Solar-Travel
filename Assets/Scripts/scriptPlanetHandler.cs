using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptPlanetHandler : MonoBehaviour
{
    public void SwitchToRocket()
    {
        SceneManager.LoadScene("sceneRocket");
    }
}
