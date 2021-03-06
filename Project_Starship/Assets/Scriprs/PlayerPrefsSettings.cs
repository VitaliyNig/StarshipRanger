using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsSettings : MonoBehaviour
{
    private void Awake()
    {
        Settings();
    }

    public static void Settings()
    {
        if (!PlayerPrefs.HasKey("Health"))
        {
            PlayerPrefs.SetInt("Health", 1);
        }
        if (!PlayerPrefs.HasKey("Fire Rate"))
        {
            PlayerPrefs.SetInt("Fire Rate", 1);
        }
        if (!PlayerPrefs.HasKey("Aim Assistance"))
        {
            PlayerPrefs.SetInt("Aim Assistance", 1);
        }
        if (!PlayerPrefs.HasKey("SpaceshipId"))
        {
            PlayerPrefs.SetInt("SpaceshipId", 2);
        }
        if (!PlayerPrefs.HasKey("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", 0);
        }
        if (!PlayerPrefs.HasKey("Money"))
        {
            PlayerPrefs.SetInt("Money", 0);
        }
        if (!PlayerPrefs.HasKey("MasterVolume"))
        {
            PlayerPrefs.SetInt("MasterVolume", 10);
        }
        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetInt("MusicVolume", 10);
        }
        if (!PlayerPrefs.HasKey("SFXVolume"))
        {
            PlayerPrefs.SetInt("SFXVolume", 10);
        }

        ShopItems shopItems = new ShopItems();
        foreach (var i in shopItems.starshipsList)
        {
            if (!PlayerPrefs.HasKey(i.StarshipsID.ToString()))
            {
                PlayerPrefs.SetString(i.StarshipsID.ToString(), i.Status.ToString());
            }
        }
    }
}
