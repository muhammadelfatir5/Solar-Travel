using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScriptRocketTime : MonoBehaviour
{
    public float duration = 10f;
    public string nextSceneName = "scenePlanetSurface";
    public TMP_Text timerText; // opsional

    private float timeLeft;
    private bool finished;

    void Start()
    {
        timeLeft = duration;
        UpdateUI();
    }

    void Update()
    {
        if (finished) return;

        timeLeft -= Time.deltaTime;
        UpdateUI();

        if (timeLeft <= 0f)
        {
            finished = true;
            SceneManager.LoadScene(nextSceneName);
        }
    }

    void UpdateUI()
    {
        if (timerText != null)
            timerText.text = Mathf.CeilToInt(Mathf.Max(timeLeft, 0f)).ToString();
    }
}