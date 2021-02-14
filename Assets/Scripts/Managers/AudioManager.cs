using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.UI;

[System.Serializable]
public class Sound
{
    public string name;//name of sound
    public AudioClip clip;//clip to play
    [Range(0,1)]
    public float volume= 0.7f; //volume of the clip  
    [Range(0,1)]
    public float pitch= 1f; //pitch of the clip
    public bool loop;
    [HideInInspector]
    public AudioSource source;//source to play
}


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;//get delegate
    private float sfxVolume;//sfx volume
    private float musicVolume;//music volume to control
    [SerializeField]
    Sound[] sounds;//make list of sounds
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        foreach(Sound s in sounds)//loop sounds
        {
            //set variables
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.pitch = s.pitch;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }
    /// <summary>
    /// func to set volume
    /// </summary>
    public void SetMusicVolume()
    {
        sounds[0].source.volume = musicVolume;
    }
    /// <summary>
    /// func to set volume
    /// </summary>
    public void SetSFXVolume()
    {
        sounds[1].source.volume = sfxVolume;
    }
    private void Update()
    {
        SetSFXVolume();
    }
    /// <summary>
    /// func to play sound
    /// </summary>
    /// <param name="name"></param>
    public void PlaySound(string name)
    {
        //search for sounds
        Sound s = Array.Find(sounds, sound => sound.name == name);
        //check s is not null
        if (s == null)
        {
            Debug.LogWarning("There is no sound");
            return;
        }
        //play
        s.source.Play();
    }
    /// <summary>
    /// function to stop sound
    /// </summary>
    /// <param name="name"></param>
    public void StopSound(string name)
    {
        //Search for sounds
        Sound s = Array.Find(sounds, sound => sound.name == name);
        //check s is not null
        if (s == null)
        {
            Debug.LogWarning("There is no sound");
            return;
        }
        //Stop
        s.source.Stop();
    }
    ///set volume
    public float Volume(float v)
    {
        return musicVolume = v;
    }///set volume
    public float SFXVolume(float v)
    {
        return sfxVolume = v;
    }
}
