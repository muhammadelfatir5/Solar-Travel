using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScriptRocketTime : MonoBehaviour
{
    public float duration = 10f;
    public TMP_Text timerText;
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
            SceneManager.LoadScene("scenePlanetSurface");
        }
    }

    void UpdateUI()
    {
        if (timerText != null)
            timerText.text = Mathf.CeilToInt(Mathf.Max(timeLeft, 0f)).ToString();
    }
}