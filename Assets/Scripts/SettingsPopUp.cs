using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopUp : PopUp
{
    [SerializeField] private Slider _fx;
    [SerializeField] private Slider _ui;
    [SerializeField] private Slider _music;
    [SerializeField] private Button _muteAll;
    [SerializeField] private Button _unmuteAll;

    public override void Start()
    {
        base.Start();
        
        _fx.value = GameManager.instance.audioManager.GetFXVolume();
        _ui.value= GameManager.instance.audioManager.GetUIVolume();
        _music.value= GameManager.instance.audioManager.GetMusicVolume();
            
        _fx.onValueChanged.AddListener(UpdateFXVolume);
        _ui.onValueChanged.AddListener(UpdateUIVolume);
        _music.onValueChanged.AddListener(UpdateMusicVolume);
    }

    private void UpdateFXVolume(float value)
    {
        GameManager.instance.audioManager.SetFXVolume(value);
    }
    
    private void UpdateUIVolume(float value)
    {
        GameManager.instance.audioManager.SetUIVolume(value);
    }
    
    private void UpdateMusicVolume(float value)
    {
        GameManager.instance.audioManager.SetBackgroundMusicVolume(value);
    }
}
