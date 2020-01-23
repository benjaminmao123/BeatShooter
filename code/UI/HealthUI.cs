using TMPro;
using UnityEngine;

public class HealthUI : Singleton<HealthUI>
{
    void Start()
    {
        Health = SettingsManager.Instance.Settings.Health;
        HealthText.text = "Health: " + Health;
    }

    private void Update()
    {
        Health = Mathf.Clamp(Health, 0, SettingsManager.Instance.Settings.Health);
        HealthText.text = "Health: " + Health;

        if (Health <= 0)
        {
            GameEvents.Death();
        }
    }

    public int Health;
    [SerializeField] TextMeshProUGUI HealthText;
}
