using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    public AudioMixer audioMixer;

    private void Start()
    {
        float valueMaster = PlayerPrefs.GetInt("MasterVolume");
        float valueMusic = PlayerPrefs.GetInt("MusicVolume");
        float valueSFX = PlayerPrefs.GetInt("SFXVolume");

        if (valueMaster == 0)
        {
            audioMixer.SetFloat("Master", -80f);
        }
        else
        {
            audioMixer.SetFloat("Master", Mathf.Log10(valueMaster / 10) * 30);
        }

        if (valueMusic == 0)
        {
            audioMixer.SetFloat("Music", -80f);
        }
        else
        {
            audioMixer.SetFloat("Music", Mathf.Log10(valueMusic / 10) * 30);
        }

        if (valueSFX == 0)
        {
            audioMixer.SetFloat("SFX", -80f);
        }
        else
        {
            audioMixer.SetFloat("SFX", Mathf.Log10(valueSFX / 10) * 30);
        }
    }
}
