using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(CanvasGroup))]
public class DeathScreen : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text bestText;

    [Header("Pengaturan")]
    [SerializeField] private float fadeDuration = 0.6f;
    [SerializeField] private bool pauseGameOnDeath = true;
    [SerializeField] private string mainMenuScene = "";

    private CanvasGroup group;
    private bool shown;
    private const string BestKey = "BestScore";

    private void Awake()
    {
        group = GetComponent<CanvasGroup>();
        group.alpha = 0f;
        group.blocksRaycasts = false;
        group.interactable = false;
    }

    public void Show() => Show(Time.timeSinceLevelLoad);

    public void Show(float score)
    {
        if (shown) return;
        shown = true;

        float best = PlayerPrefs.GetFloat(BestKey, 0f);
        if (score > best)
        {
            best = score;
            PlayerPrefs.SetFloat(BestKey, best);
            PlayerPrefs.Save();
        }

        if (scoreText != null) scoreText.text = $"Waktu: {score:0.0}s";
        if (bestText != null) bestText.text = $"Terbaik: {best:0.0}s";

        group.blocksRaycasts = true;
        group.interactable = true;
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.unscaledDeltaTime;
            group.alpha = Mathf.Clamp01(t / fadeDuration);
            yield return null;
        }
        group.alpha = 1f;
        if (pauseGameOnDeath) Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        if (!string.IsNullOrEmpty(mainMenuScene)) SceneManager.LoadScene(mainMenuScene);
    }
}