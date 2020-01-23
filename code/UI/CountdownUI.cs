using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownUI : MonoBehaviour
{
    void Start()
    {
        StartTime = SettingsManager.Instance.Settings.StartDelay;
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while (true)
        {
            CountdownText.text = "Starting in: " + StartTime;

            if (StartTime <= 0)
            {
                break;
            }

            yield return new WaitForSeconds(1);

            StartTime -= 1;
        }

        CountdownText.gameObject.SetActive(false);
    }

    [SerializeField] TextMeshProUGUI CountdownText;
    float StartTime;
}
