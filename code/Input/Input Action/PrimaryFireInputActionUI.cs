using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrimaryFireInputActionUI : MonoBehaviour, IInputAction
{ 
    void Start()
    {
        Laser = FindObjectOfType<Laser>();
    }

    public void Execute()
    {
        if (Laser.Hit.collider)
        {
            Button button = Laser.Hit.collider.GetComponent<Button>();

            if (button)
            {
                if (button.enabled)
                {
                    if (button.GetComponent<PreviewSong>())
                    {
                        button.onClick.RemoveAllListeners();
                        string name = button.GetComponentInChildren<TextMeshProUGUI>().text;
                        button.onClick.AddListener(delegate { SongManager.Instance.SetSong(name); });
                        button.onClick.AddListener(delegate { AudioManager.Instance.Stop(name); });
                        button.onClick.AddListener(delegate { LevelManager.Instance.LoadNextScene("Game"); });
                    }

                    button.onClick.Invoke();
                }
            }
        }
    }

    Laser Laser;
}
