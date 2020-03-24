using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

/// <summary>
/// The idea of my this SoundManager class is to hold a list of sounds that I can easily add and remove.
/// It has an audio clip, a volume and pitch setting, possibily to loop. You can add stuff like volume and pitch randomness or spatial blend.
/// When I want to add a sound, I will simply call a play menthod on the sound manager, where I input the name of the sound that I want to play,
/// the sound manager will find the source with that name from the list of sounds and play the sound.
/// I need a list of sounds and I want to be able to control what data is stored in each.
/// </summary>

public class SoundManager : MonoBehaviour
{
    public List<Sound> sounds;

    // Awake to act as a constructor
    private void Awake()
    {
        for (int i = 0; i < sounds.Count; i++)
        {
            sounds[i].audioSource = gameObject.AddComponent<AudioSource>();

            sounds[i].audioSource.clip = sounds[i].audio;
            sounds[i].audioSource.volume = sounds[i].audioVolume;
            sounds[i].audioSource.pitch = sounds[i].audioPitch;
            sounds[i].audioSource.loop = sounds[i].loop;
            sounds[i].audioSource.spatialBlend = sounds[i].blend;
        }
    }

    //Start is called before the first frame update.
    private void Start()
    {
        PlayBackgroundMusic();
    }

    /// <summary>
    /// Here I have written a function that will go through the list of sounds that I have added and Play the sound.
    /// I can call this function in any other class if I want a specific sound to be played.
    /// For example, in my Playership Class, when an enemy missile or enemy ship collide with the player ship, I call this Play
    /// method to play the sound, to indicate to the player that they have taken damage and lost health points.
    /// </summary>
    /// <param name="name"> The name of the sound that you want to play from the list of sounds. </param>
    public void Play(string name)
    {
        try
        {
            Sound sound = sounds.Find(s => s.audioName == name);
            sound.audioSource.Play();
        }
        catch(NullReferenceException e)
        {
            Debug.Log(e);
        }
    }

    /// <summary>
    /// Here I have written a function that will go through the list of sounds that I have added and Pause the sound.
    /// This function can be used in a similar way like the Play method is used.
    /// </summary>
    /// <param name="name"> The name of the sound that you want to play from the list of sounds. </param>
    public void PauseBGM(string name)
    {
        try
        {
            Sound sound = sounds.Find(s => s.audioName == name);
            sound.audioSource.Pause();
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e);
        }
    }

    /// <summary>
    /// Here I have written a function that will go through the list of sounds that I have added and stop playing the background music.
    /// This function can be used in a similar way like the Play method is used.
    /// </summary>
    /// <param name="name"> The name of the sound that you want to play from the list of sounds. </param>
    public void StopBGM(string name)
    {
        try
        {
            Sound sound = sounds.Find(s => s.audioName == name);
            sound.audioSource.Stop();
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e);
        }
    }

    /// <summary>
    /// Here I have written a function that will go through the list of sounds that I have added and play the sound only once.
    /// This method is attached to each button in the game. When the player clicks the button sound is played, to indicate to them
    /// that they are interacting with that specific button.
    /// </summary>
    /// <param name="name"> The name of the sound that you want to play from the list of sounds. </param>
    public void PlayOnce(string name)
    {
        try
        {
            Sound sound = sounds.Find(s => s.audioName == name);
            sound.audioSource.PlayOneShot(sound.audio);
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e);
        }
    }

    /// <summary>
    /// I have written this function to play sound when the button is clicked.
    /// </summary>
    public void ButtonClick()
    {
        PlayOnce("ButtonClick");
    }

    /// <summary>
    /// I have written this function to play sound when the player hovers over a button.
    /// </summary>
    public void ButtonHover()
    {
        PlayOnce("ButtonHover");
    }

    /// <summary>
    /// I have written this function to play the background music when the scene is loaded or reloaded.
    /// </summary>
    private void PlayBackgroundMusic()
    {
        Play("BackgroundMusic");
    }
}
