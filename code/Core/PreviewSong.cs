using UnityEngine;

public class PreviewSong : MonoBehaviour
{
    public void Preview(string name)
    {
        CurrentSong = name;
        AudioManager.Instance.Play(name);
    }

    public string CurrentSong;
}
