using UnityEngine;

[System.Serializable]
public class Sound
{
    public string Name;
    [HideInInspector] public AudioSource Source;
    [Range(0f, 1f)] public float Volume = 0.5f;
    [Range(0f, 1f)] public float Pitch = 1f;
    public AudioClip Clip;
}
