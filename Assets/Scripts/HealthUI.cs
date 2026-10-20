using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Gradient colorByHealth;

    public void UpdateHealth(int current, int max)
    {
        float ratio = max > 0 ? (float)current / max : 0f;

        if (fillImage != null)
        {
            fillImage.fillAmount = ratio;
            if (colorByHealth != null && colorByHealth.colorKeys.Length > 0)
                fillImage.color = colorByHealth.Evaluate(ratio);
        }

        if (healthText != null)
            healthText.text = $"HP {current}/{max}";
    }
}
