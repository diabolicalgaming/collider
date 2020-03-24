using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// This is a custom class that I wrote to hold the audio source.
/// When you create a custom class and want it to show in the inspector, it must be marked as system.serializable
/// </summary>
[System.Serializable]
public class Sound
{
    [HideInInspector]
    public AudioSource audioSource;

    public bool loop;
    public AudioClip audio;
    public string audioName;
    public float audioPitch;
    public float audioVolume;
    public float blend; //spatial blend of audio source of means that is 2D audio.
}
