using System;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in Sounds)
        {
            s.Source = gameObject.AddComponent<AudioSource>();

            s.Source.clip = s.Clip;
            s.Source.volume = s.Volume;
            s.Source.pitch = s.Pitch;
        }
    }

    public void Play(string name)
    {
        Sound sound = Array.Find(Sounds, s => s.Name == name);

        if (sound != null) 
        {
            CurrentSound = sound;
            sound.Source.Play();
        }
    }

    public void Stop(string name)
    {
        Sound sound = Array.Find(Sounds, s => s.Name == name);

        if (sound != null)
        {
            sound.Source.Stop();
        }
    }

    Sound CurrentSound;
    public Sound[] Sounds;
}
