using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    private void OnEnable()
    {
        UIEvents.OnScoreChanged += OnScoreChanged;
    }
    void Start()
    {
        Score = 0;
        ScoreText.text = "Score: " + Score;
        PlayerPrefs.SetInt("Score", Score);
    }

    void OnScoreChanged(int value)
    {
        Score += value;
        ScoreText.text = "Score: " + Score;
        PlayerPrefs.SetInt("Score", Score);
    }

    private void OnDisable()
    {
        UIEvents.OnScoreChanged -= OnScoreChanged;
    }

    [SerializeField] int Score;
    [SerializeField] TextMeshProUGUI ScoreText;
}
