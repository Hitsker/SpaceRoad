using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource FXSource;
    [SerializeField] private AudioSource UISource;
    [SerializeField] private AudioSource MusicSource;

    //I wanted ro make dictionary here, but it wasnt serializable, so I make first came to mind
    [SerializeField] private List<SoundItem> _sounds;

    private void Start()
    {
        SetFXVolume(PlayerPrefs.GetFloat("FXVolume"));
        SetUIVolume(PlayerPrefs.GetFloat("UIVolume"));
        SetBackgroundMusicVolume(PlayerPrefs.GetFloat("MusicVolume"));
    }

    public void PlayFX(Sound sound)
    {
        foreach (var soundItem in _sounds.Where(soundItem => soundItem.Sound==sound))
        {
            FXSource.PlayOneShot(soundItem.Clip);
            break;
        }
    }

    public void PlayUI(Sound sound)
    {
        foreach (var soundItem in _sounds.Where(soundItem => soundItem.Sound==sound))
        {
            UISource.PlayOneShot(soundItem.Clip);
            break;
        }
    }

    public void SetBackgroundMusic(Sound sound)
    {
        foreach (var soundItem in _sounds.Where(soundItem => soundItem.Sound==sound))
        {
            MusicSource.PlayOneShot(soundItem.Clip);
            break;
        }
    }

    public void SetFXVolume(float volume)
    {
        FXSource.volume = volume;
        PlayerPrefs.SetFloat("FXVolume", volume);
    }

    public void SetBackgroundMusicVolume(float volume)
    {
        MusicSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetUIVolume(float volume)
    {
        UISource.volume = volume;
        PlayerPrefs.SetFloat("UIVolume", volume);
    }

    public void MuteAll()
    {
        FXSource.enabled = false;
        MusicSource.enabled = false;
        UISource.enabled = false;
    }

    public void UnmuteAll()
    {
        FXSource.enabled = true;
        MusicSource.enabled = true;
        UISource.enabled = true;
    }

    public float GetFXVolume()
    {
        return PlayerPrefs.GetFloat("FXVolume");
    }

    public float GetUIVolume()
    {
        return PlayerPrefs.GetFloat("UIVolume");
    }

    public float GetMusicVolume()
    {
        return PlayerPrefs.GetFloat("MusicVolume");
    }
}

public enum Sound
{
    Explosion,
    Click,
    Music,
}
[Serializable]
public class SoundItem
{
    [SerializeField] private Sound _sound;
    [SerializeField] private AudioClip _clip;

    public Sound Sound => _sound;

    public AudioClip Clip => _clip;
}