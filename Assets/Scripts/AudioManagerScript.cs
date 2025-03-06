using UnityEngine;
using System;
using UnityEngine.Audio;


public class AudioManagerScript : MonoBehaviour
{
    public Sound[] sounds;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name, float volume = 1.0f, float pitch = 1.0f)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + ", not found");
            return;
        }
        s.pitch = pitch;
        s.source.pitch = pitch;
        s.volume = volume;
        s.source.volume = volume;
        s.source.Play();
    }
}
