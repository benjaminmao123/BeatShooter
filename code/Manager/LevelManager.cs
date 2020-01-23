using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(gameObject);
    }
    public void LoadNextScene(string name)
    {
        AudioManager.Instance.Stop(SongManager.Instance.CurrentSong.Name);
        Initiate.Fade(name, FadeColor, FadeTime);
    }

    [SerializeField] float FadeTime;
    [SerializeField] Color FadeColor;
}
