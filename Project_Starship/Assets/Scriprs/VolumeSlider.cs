using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider sfxSlider;
    public Text musicText;
    public Text sfxText;
    
    void Start()
    {
        musicSlider.value = PlayerPrefs.GetInt("MusicVolume");
        sfxSlider.value = PlayerPrefs.GetInt("SFXVolume");
    }

    public void UpdateMusicValue() 
    {
        musicText.text = (musicSlider.value * 10).ToString() + "%";
        if(musicSlider.value == 0)
        {
            audioMixer.SetFloat("Music", -80f);
        }
        else
        {
            audioMixer.SetFloat("Music", Mathf.Log10(musicSlider.value / 10) * 20);
        }
    }

    public void UpdateSFXValue() 
    {
        sfxText.text = (sfxSlider.value * 10).ToString() + "%";
        if(sfxSlider.value == 0)
        {
            audioMixer.SetFloat("SFX", -80f);
        }
        else
        {
            audioMixer.SetFloat("SFX", Mathf.Log10(sfxSlider.value / 10) * 20);
        }
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("MusicVolume", (int)musicSlider.value);
        PlayerPrefs.SetInt("SFXVolume", (int)sfxSlider.value);
    }
}
