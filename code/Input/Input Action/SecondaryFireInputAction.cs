using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SecondaryFireInputAction : MonoBehaviour, IInputAction
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
                    PreviewSong previewSong = button.GetComponent<PreviewSong>();
                    
                    if (previewSong)
                    {
                        if (PreviewSong)
                        {
                            AudioManager.Instance.Stop(PreviewSong.CurrentSong);
                        }

                        previewSong.Preview(button.GetComponentInChildren<TextMeshProUGUI>().text);
                        PreviewSong = previewSong;
                    }
                    else
                    {
                        if (PreviewSong)
                        {
                            AudioManager.Instance.Stop(PreviewSong.CurrentSong);
                            PreviewSong = null;
                        }
                    }
                }
            }
            else
            {
                if (PreviewSong)
                {
                    AudioManager.Instance.Stop(PreviewSong.CurrentSong);
                    PreviewSong = null;
                }
            }
        }
    }

    Laser Laser;
    PreviewSong PreviewSong;
}
