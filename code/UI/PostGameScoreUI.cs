using UnityEngine;
using TMPro;

public class PostGameScoreUI : MonoBehaviour
{
    void Start()
    {
        Score = PlayerPrefs.GetInt("Score");

        if (SongManager.Instance.CurrentSong)
        {
            ScoreText.text = "Score: " + Score.ToString() + "/" + SongManager.Instance.CurrentSong.TotalScore;
        }
    }

    int Score;
    [SerializeField] TextMeshProUGUI ScoreText;
}
