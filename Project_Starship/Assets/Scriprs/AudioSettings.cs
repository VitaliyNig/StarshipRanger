using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    public AudioMixer audioMixer;

    private void Start()
    {
        float valueMusic = PlayerPrefs.GetInt("MusicVolume");
        float valueSFX = PlayerPrefs.GetInt("SFXVolume");

        if (valueMusic == 0)
        {
            audioMixer.SetFloat("Music", -80f);
        }
        else
        {
            audioMixer.SetFloat("Music", Mathf.Log10(valueMusic / 10) * 20);
        }

        if (valueSFX == 0)
        {
            audioMixer.SetFloat("SFX", -80f);
        }
        else
        {
            audioMixer.SetFloat("SFX", Mathf.Log10(valueSFX / 10) * 20);
        }
    }
}
